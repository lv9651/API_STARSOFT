using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using STARSOFT_API.Areas.ORDER_COMPRA.Modelo;
using System.Data;
using System.Threading.Tasks;


namespace TuProyecto.Repositories
{
    public class ImportacionRepository : IImportacionRepository
    {
        private readonly string _connectionString;

        public ImportacionRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConnectionSIGE");
        }

        public async Task<ImportacionData> ObtenerDatosPorOrdenCompraAsync(string ordenCompra)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var datos = new ImportacionData
            {
                TablaInvoice = (await connection.QueryAsync<TablaInvoice>(
                    "SELECT * FROM TablaInvoice WHERE OrdenCompra = @OrdenCompra",
                    new { OrdenCompra = ordenCompra })).AsList(),

                TablaCaltimereal = (await connection.QueryAsync<TablaCaltimereal>(
                    "SELECT * FROM TablaCaltimereal WHERE OrdenCompra = @OrdenCompra",
                    new { OrdenCompra = ordenCompra })).AsList(),

                TablaDua = (await connection.QueryAsync<TablaDua>(
                    "SELECT * FROM TablaDua WHERE OrdenCompra = @OrdenCompra",
                    new { OrdenCompra = ordenCompra })).AsList(),

                DistribucionFinal = (await connection.QueryAsync<DistribucionFinal>(
                    "SELECT * FROM DistribucionFinal WHERE OrdenCompra = @OrdenCompra",
                    new { OrdenCompra = ordenCompra })).AsList(),
            };

            return datos;
        }

        public async Task RegistrarImportacionAsync(ImportacionRequest request)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.ExecuteAsync(
                "sp_RegistrarDatosDesdeJson",
                new
                {
                    jsonInvoice = request.JsonInvoice,
                    jsonCaltimereal = request.JsonCaltimereal,
                    jsonDua = request.JsonDua,
                    jsonDistribucionFinal = request.JsonDistribucionFinal
                },
                commandType: CommandType.StoredProcedure);
        }
    }
}