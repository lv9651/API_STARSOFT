using Dapper;
using System.Data;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;


namespace CLINICA_API.Areas.General.Helpers
{
    public class ServiceConnection
    {
        private readonly string? _connection;
        public ServiceConnection(IConfiguration configuration) {
            _connection = configuration.GetConnectionString("ConnectionClinica");

        }
        public string MetodoDatatabletostringsql(string procedimiento, DynamicParameters parametros)
        {                                                                               
            try
            {
                using (var connection = new SqlConnection(_connection))
                {
                    var datatable = new DataTable();

                    using (var command = new SqlCommand(procedimiento, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        if (parametros is not null)
                        {
                            // Agregar parámetros al comando
                            foreach (var param in parametros.ParameterNames)
                            {
                                command.Parameters.Add(new SqlParameter(param, parametros.Get<dynamic>(param)));
                            }
                        }

                        // Llenar el DataTable con el resultado
                        using (var adapter = new SqlDataAdapter(command))
                        {
                            connection.Open();
                            adapter.Fill(datatable);
                        }
                    }

                    // Convertir el DataTable a JSON y devolverlo
                    return JsonConvert.SerializeObject(datatable);
                }
            }
            catch (Exception ex)
            {
                // Manejar excepciones
                return null;
            }
        }

        public  string MetodoRespuestasql(string procedimiento,DynamicParameters parametros,int sizeParametroSalida)
        {
            try
            {
                string parametrosalida = "@respuesta";
                using (var connection = new SqlConnection(_connection))
                {
                    // Asignar el tamaño y tipo al parámetro de salida
                    parametros.Add(parametrosalida, dbType: DbType.String, size: sizeParametroSalida, direction: ParameterDirection.Output);

                    // Ejecutar el procedimiento almacenado
                    var result =  connection.QueryAsync(procedimiento, parametros, commandType: CommandType.StoredProcedure);

                    // Obtener el valor del parámetro de salida
                    string mensajeSalida = parametros.Get<string>(parametrosalida);

                    return mensajeSalida;
                }
            }
            catch (Exception vEx)
            {
                // Manejar excepciones
                return vEx.Message.ToString();
            }
        }
        public async Task<string> MetodoDatatabletostringsqlasync(string procedimiento, DynamicParameters parametros)
        {
            try
            {
                using (var connection = new SqlConnection(_connection))
                {
                    var datatable = new DataTable();

                    using (var command = new SqlCommand(procedimiento, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        if (parametros is not null) {
                            // Agregar parámetros al comando
                            foreach (var param in parametros.ParameterNames)
                            {
                                command.Parameters.Add(new SqlParameter(param, parametros.Get<dynamic>(param)));
                            }
                        }

                        // Llenar el DataTable con el resultado
                        using (var adapter = new SqlDataAdapter(command))
                        {
                            await connection.OpenAsync();
                            adapter.Fill(datatable);
                        }
                    }

                    // Convertir el DataTable a JSON y devolverlo
                    return JsonConvert.SerializeObject(datatable);
                }
            }
            catch (Exception ex)
            {
                // Manejar excepciones
                return null;
            }
        }
       
        

    }
}
