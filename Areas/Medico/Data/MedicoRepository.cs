using Dapper;
using Microsoft.Data.SqlClient;

using SISLAB_API.Areas.Maestros.Models;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;

public class MedicoRepository
{
    private readonly string? _connectionString;

    // Constructor que obtiene la cadena de conexión desde la configuración
    public MedicoRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("ConnectionClinica");
    }

    // Método para obtener especialidades
    public async Task<IEnumerable<Medico>> ObtenerEspecialidadesAsync()
    {
        var especialidades = new List<Medico>();

        // Consulta SQL adaptada para SQL Server
        string query = @"
           SELECT med_esp.descripcion
FROM medico.Medico Med
INNER JOIN Medico.Especialidad med_esp 
    ON Med.idespecialidad = med_esp.idespecialidad
INNER JOIN General.Usuario Us 
    ON Med.idusuario = Us.idusuario
	where med_esp.descripcion not in('CARDIOLOGIA','CIRUGIA CARDIOVASCULAR','CIRUGIA GENERAL','DIMPLOMATURA EN AUDITORIA MEDICA','ENDOCRINOLOGIA',
	'ENDOCRINOLOGIA Y NUTRICION','GASTROENTEROLOGIA','GINECOLOGIA Y OBSTETRICIA','MEDICINA GENERAL INTEGRAL','MEDICINA INTERNA','MEDICO - CIRUJANO',
	'NINGUNO','OTORRINOLARINGOLOGIA','PODOLOGO','PSIQUIATRIA','REUMATOLOGIA','TERAPIA INTENSIVA','UROLOGIA ')
GROUP BY med_esp.descripcion";

        // Usando Dapper para ejecutar la consulta y mapear los resultados
        using (var connection = new SqlConnection(_connectionString))  // Usando SqlConnection para SQL Server
        {
            await connection.OpenAsync();
            var result = await connection.QueryAsync<Medico>(query);  // Dapper ejecutará la consulta

            especialidades = result.AsList();  // Convertir el resultado a una lista
        }

        return especialidades;  // Retornar la lista de especialidades
    }




    public async Task<IEnumerable<Sucursal>> ObtenerSucursalesAsync(string descripcionEspecialidad)
    {
        var especialidades = new List<Sucursal>();
          string query = "bus_espec";

        // Consulta SQL adaptada para SQL Server
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();

            // Ejecutamos el procedimiento almacenado pasando el parámetro 'descripcion'
            var result = await connection.QueryAsync<Sucursal>(
            query, // Nombre del procedimiento almacenado
                new { especialidad = descripcionEspecialidad }, // Parámetro que le pasamos al procedimiento
                commandType: System.Data.CommandType.StoredProcedure // Especificamos que es un procedimiento almacenado
            );

            especialidades = result.AsList();  // Convertimos el resultado en una lista
        }

        return especialidades;  // Retorn // Retornar la lista de especialidades
    }

    public async Task<IEnumerable<Banner>> ObtenerBannerAsync()
    {
        var especialidades = new List<Banner>();

        // Consulta SQL adaptada para SQL Server
        string query = @"select imagenbyte,rutaurl  from General.ImagenPublicitaria where  idestado=1 ";

        // Usando Dapper para ejecutar la consulta y mapear los resultados
        using (var connection = new SqlConnection(_connectionString))  // Usando SqlConnection para SQL Server
        {
            await connection.OpenAsync();
            var result = await connection.QueryAsync<Banner>(query);  // Dapper ejecutará la consulta

            especialidades = result.AsList();  // Convertir el resultado a una lista
        }

        return especialidades;  // Retornar la lista de especialidades
    }




    public async Task<IEnumerable<Med_bus>> BuscarMedicoPorEspecialidadAsync(string descripcionEspecialidad)
    {
        var médicos = new List<Med_bus>();

        // Llamamos al procedimiento almacenado
        string query = "buscar_medico_x_especialidad";  // Nombre del procedimiento almacenado

        // Usamos Dapper para ejecutar el procedimiento almacenado
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            var result = await connection.QueryAsync<Med_bus>(
                query,
                new { descripcion = descripcionEspecialidad }, // Pasamos el parámetro @descripcion
                commandType: System.Data.CommandType.StoredProcedure  // Especificamos que es un procedimiento almacenado
            );

            médicos = result.AsList();
        }

        return médicos;  // Retorna la lista de médicos
    }


    public async Task<IEnumerable<Dependiente>> BuscarDependienteAsync(string dni)
    {
        var médicos = new List<Dependiente>();

        // Llamamos al procedimiento almacenado
        string query = "buscar_dependiente";  // Nombre del procedimiento almacenado

        // Usamos Dapper para ejecutar el procedimiento almacenado
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            var result = await connection.QueryAsync<Dependiente>(
                query,
                new { dni = dni }, // Pasamos el parámetro @descripcion
                commandType: System.Data.CommandType.StoredProcedure  // Especificamos que es un procedimiento almacenado
            );

            médicos = result.AsList();
        }

        return médicos;  // Retorna la lista de médicos
    }


    public async Task<IEnumerable<Paciente>> BuscaridPacienteAsync(string dni)
    {
        var médicos = new List<Paciente>();

        // Llamamos al procedimiento almacenado
        string query = "bus_pac";  // Nombre del procedimiento almacenado

        // Usamos Dapper para ejecutar el procedimiento almacenado
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            var result = await connection.QueryAsync<Paciente>(
                query,
                new { dni = dni }, // Pasamos el parámetro @descripcion
                commandType: System.Data.CommandType.StoredProcedure  // Especificamos que es un procedimiento almacenado
            );

            médicos = result.AsList();
        }

        return médicos;  // Retorna la lista de médicos
    }

    public async Task<List<RecetaCliente>> GetRecetasByCitaIdAsync(int idCita)
    {
        var sqlQuery = "EXEC Mostrar_Receta_cliente @idcita";

        using (var connection = new SqlConnection(_connectionString))
        {
            // Abrir la conexión
            await connection.OpenAsync();

            // Ejecutar la consulta con Dapper
            var result = await connection.QueryAsync<RecetaCliente, string, string, RecetaCliente>(
                sqlQuery,
                (receta, datosClienteJson,formulaJson ) =>
                {
                    // Deserializar la fórmula JSON

                    receta.formula = string.IsNullOrEmpty(formulaJson)
                        ? new List<FormulaComponent>()
                        : Newtonsoft.Json.JsonConvert.DeserializeObject<List<FormulaComponent>>(formulaJson);

                    receta.datos_cliente = string.IsNullOrEmpty(datosClienteJson)
                       ? new List<DatosCliente>()
                       : Newtonsoft.Json.JsonConvert.DeserializeObject<List<DatosCliente>>(datosClienteJson);


                    // Deserializar los datos del cliente JSON
                   

                    return receta;
                },
                new { idcita = idCita },
                splitOn: "datos_cliente,formula"  // Especifica la columna que separa los diferentes resultados
            );

            // Retornar la lista de recetas
            return result.ToList();
        }
    }

    public async Task<IEnumerable<string>> ActCliHist(string dni, string email, string clave)
    {
        // Definimos una lista para almacenar los resultados del procedimiento almacenado
        var resultados = new List<string>();

        try
        {
            // Llamamos al procedimiento almacenado
            string query = "actualizar_cliente_historico";  // Nombre del procedimiento almacenado

            // Usamos Dapper para ejecutar el procedimiento almacenado
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                // Ejecutamos el procedimiento almacenado
                var result = await connection.QueryAsync<string>(
                    query,
                    new { nrodocumento = dni, email = email, clave = clave },
                    commandType: System.Data.CommandType.StoredProcedure // Especificamos que es un procedimiento almacenado
                );

                // Si el procedimiento devuelve resultados, los agregamos a la lista
                resultados = result.ToList();

                // Si no hay resultados y quieres devolver un mensaje, puedes agregarlo
                if (!resultados.Any())
                {
                    resultados.Add("No se encontraron resultados");
                }
            }
        }
        catch (Exception ex)
        {
            // Manejo de errores, puedes registrar o devolver el mensaje de error
            resultados.Add($"Error: {ex.Message}");
        }

        // Devolvemos la lista de resultados
        return resultados;
    }


    public async Task<IEnumerable<Bus_cita_cliente>> Busq_cita_clienteAsync(string documento)
    {
        var BusqCita = new List<Bus_cita_cliente>();

        // Llamamos al procedimiento almacenado
        string query = "mostrar_cita_guardadas_cliente";  // Nombre del procedimiento almacenado

        // Usamos Dapper para ejecutar el procedimiento almacenado
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            var result = await connection.QueryAsync<Bus_cita_cliente>(
                query,
                new { idcliente = documento }, // Pasamos el parámetro @descripcion
                commandType: System.Data.CommandType.StoredProcedure  // Especificamos que es un procedimiento almacenado
            );

            BusqCita = result.AsList();
        }

        return BusqCita;  // Retorna la lista de médicos
    }

    public async Task<IEnumerable<PacienteDependiente>> Busq_PacienteDependienteAsync(string documento)
    {
        var BusqCita = new List<PacienteDependiente>();

        // Llamamos al procedimiento almacenado
        string query = "bus_depend_paciente";  // Nombre del procedimiento almacenado

        // Usamos Dapper para ejecutar el procedimiento almacenado
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            var result = await connection.QueryAsync<PacienteDependiente>(
                query,
                new { dni = documento }, // Pasamos el parámetro @descripcion
                commandType: System.Data.CommandType.StoredProcedure  // Especificamos que es un procedimiento almacenado
            );

            BusqCita = result.AsList();
        }

        return BusqCita;  // Retorna la lista de médicos
    }


    public async Task<IEnumerable<Historial_clinico>> Busq_HistorialClinicoAsync(string documento)
    {
        var BusqCita = new List<Historial_clinico>();

        // Llamamos al procedimiento almacenado
        string query = "[Citas].[sp_obtener_historialclinicoxidpaciente]";  // Nombre del procedimiento almacenado

        // Usamos Dapper para ejecutar el procedimiento almacenado
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            var result = await connection.QueryAsync<Historial_clinico>(
                query,
                new { idpaciente = documento }, // Pasamos el parámetro @descripcion
                commandType: System.Data.CommandType.StoredProcedure  // Especificamos que es un procedimiento almacenado
            );

            BusqCita = result.AsList();
        }

        return BusqCita;  // Retorna la lista de médicos
    }



    public async Task<int> InsertarFammedAsync(Reg_pariente request)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();

            var parameters = new DynamicParameters();
            parameters.Add("@json", request.Json);

            // Ejecutar el procedimiento almacenado e insertar los datos
            var cliCodigo = await connection.QuerySingleOrDefaultAsync<int>(
                "insertar_paciente_familiar",
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return cliCodigo;  // Retornar el cli_codigo insertado
        }
    }



    public async Task<int> ActCliente_VinAsync(Reg_pariente request)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();

            var parameters = new DynamicParameters();
            parameters.Add("@json", request.Json);

            // Ejecutar el procedimiento almacenado e insertar los datos
            var cliCodigo = await connection.QuerySingleOrDefaultAsync<int>(
                "Act_cli_Vinali",
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return cliCodigo;  // Retornar el cli_codigo insertado
        }
    }










    public async Task<IEnumerable<Tipo_pago>> ObtenerTipoPago()
    {
        var especialidades = new List<Tipo_pago>();

        // Consulta SQL adaptada para SQL Server
        string query = "General.sp_listar_tipopago_combo";

        // Usando Dapper para ejecutar la consulta y mapear los resultados
        using (var connection = new SqlConnection(_connectionString))  // Usando SqlConnection para SQL Server
        {
            await connection.OpenAsync();
            var result = await connection.QueryAsync<Tipo_pago>(query);  // Dapper ejecutará la consulta

            especialidades = result.AsList();  // Convertir el resultado a una lista
        }

        return especialidades;  // Retornar la lista de especialidades
    }




    public async Task<IEnumerable<Busq_dia_med>> BuscardiaMedicoAsync(string colegio)
    {
        var médicos = new List<Busq_dia_med>();

        // Llamamos al procedimiento almacenado
        string query = "buscar_dia_medico";  // Nombre del procedimiento almacenado

        // Usamos Dapper para ejecutar el procedimiento almacenado
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            var result = await connection.QueryAsync<Busq_dia_med>(
                query,
                new { colegio = colegio }, // Pasamos el parámetro @descripcion
                commandType: System.Data.CommandType.StoredProcedure  // Especificamos que es un procedimiento almacenado
            );

            médicos = result.AsList();
        }

        return médicos;  // Retorna la lista de médicos
    }



    // Método para ejecutar el procedimiento almacenado
    public async Task<IEnumerable<Hor_dia_med>> BuscarDiaHoraMedicoAsync(string fecha, string colegio,string idmodalidad)
    {
        var horarioDiaMedicoList = new List<Hor_dia_med>();

        using (var connection = new SqlConnection(_connectionString)) // Usamos SqlConnection para SQL Server
        {
            await connection.OpenAsync();

            using (var command = new SqlCommand("horario_dia_medico", connection)) // Usamos SqlCommand para SQL Server
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@fecha", fecha);
                command.Parameters.AddWithValue("@colegio", colegio);
                command.Parameters.AddWithValue("@idmodalidad", idmodalidad);


                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var horarioDiaMedico = new Hor_dia_med
                        {
                            idhorariomedicodividido  = reader["idhorariomedicodividido"].ToString(),
                            horainicio = reader["horainicio"].ToString(),
                            fecha = Convert.ToDateTime(reader["fecha"]),
                            idestado = reader["idestado"].ToString()
                        };

                        horarioDiaMedicoList.Add(horarioDiaMedico);
                    }
                }
            }
        }

        return horarioDiaMedicoList;
    }







    public async Task<IEnumerable<Result_Precio>> BuscarPrecioAsync(string especialidad, int idsucursal)
    {
        var horarioDiaMedicoList = new List<Result_Precio>();

        using (var connection = new SqlConnection(_connectionString)) // Usamos SqlConnection para SQL Server
        {
            await connection.OpenAsync();

            using (var command = new SqlCommand("ObtenerPreciosFiltrados", connection)) // Usamos SqlCommand para SQL Server
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@p_especialidad", especialidad);
                command.Parameters.AddWithValue("@p_idsucursal", idsucursal);
        


                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var horarioDiaMedico = new Result_Precio
                        {
                            idprecioproducto = reader["idprecioproducto"].ToString(),
                            idproducto = reader["idproducto"].ToString(),

                            precio = reader["precio"].ToString()
                        };

                        horarioDiaMedicoList.Add(horarioDiaMedico);
                    }
                }
            }
        }

        return horarioDiaMedicoList;
    }

}