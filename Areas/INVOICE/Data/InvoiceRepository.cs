using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Text.Json;

public class InvoiceRepository
{
    private readonly IConfiguration _configuration;

    public InvoiceRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }


    public async Task<IEnumerable<Importacion>> ObtenerPorFechaAsync(string fechaInicio, string fechaFin)
    {
        using (var connection1 = new SqlConnection(_configuration.GetConnectionString("ConnectionSIGE")))
        {
            var parameters = new DynamicParameters();
            parameters.Add("@fechainicio", fechaInicio, DbType.String);
            parameters.Add("@fechafin", fechaFin, DbType.String);

            return await connection1.QueryAsync<Importacion>(
                "Contabilidad.importaciones",
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }
    }

    public async Task<OrdenCompra> ObtenerPorInvoiceAsync(string invoice)
    {
        var ordenCompra = new OrdenCompra();

        // PRIMERA CONEXIÓN - Obtener la orden de compra
        using (var connection1 = new SqlConnection(_configuration.GetConnectionString("ConnectionStarsoft")))
        {
            await connection1.OpenAsync();

            var result = await connection1.QueryFirstOrDefaultAsync<string>(
                "sp_ObtenePorOrdenCompra_x_invoice",
                new { INVOICE = invoice },
                commandType: CommandType.StoredProcedure);

            if (result != null)
            {
                var jsonDocument = JsonDocument.Parse(result);
                var root = jsonDocument.RootElement;

                ordenCompra.CodigoOrdenCompra = root.GetProperty("ordenCompra").GetString();

                if (root.TryGetProperty("movimientos", out var movimientos))
                {
                    ordenCompra.Movimientos = JsonSerializer.Deserialize<List<MovimientoContable>>(movimientos.GetRawText());
                }
                else if (root.TryGetProperty("mensaje", out var mensaje))
                {
                    ordenCompra.MensajeError = mensaje.GetString();
                    return ordenCompra; // Retorna si hay error
                }
            }
        }

        // SEGUNDA CONEXIÓN - Solo si obtuvimos una orden de compra válida
        if (!string.IsNullOrEmpty(ordenCompra.CodigoOrdenCompra))
        {
            using (var connection2 = new SqlConnection(_configuration.GetConnectionString("ConnectionSIGE"))) // Asegúrate de agregar esta cadena de conexión
            {
                await connection2.OpenAsync();

                // Ejecutar el segundo procedimiento almacenado
                var datosAdicionales = await connection2.QueryAsync<Detail_Ord_compra>(
                    "sp_OrdenCompra_x_invoice", // Nombre de tu segundo procedimiento
                    new { ORDCOMPRA = ordenCompra.CodigoOrdenCompra },
                    commandType: CommandType.StoredProcedure);

                ordenCompra.DatosAdicionales = datosAdicionales.ToList();
            }
        }

        return ordenCompra;
    }
}