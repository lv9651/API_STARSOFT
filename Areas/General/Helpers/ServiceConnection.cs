using Dapper;
using System.Data;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authentication.Cookies;


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
                string respuesta = "";
                using (var connection = new SqlConnection(_connection))
                {
                    using (var command = new SqlCommand(procedimiento, connection)) { 
                        command.CommandType = CommandType.StoredProcedure;
                        if (parametros is not null) {
                            foreach (var param in parametros.ParameterNames) {
                                command.Parameters.AddWithValue(param, parametros.Get<dynamic>(param));
                            }
                            command.Parameters.Add(parametrosalida,SqlDbType.VarChar,sizeParametroSalida).Direction=ParameterDirection.Output;
                        }
                        connection.Open();
                        if (command.ExecuteNonQuery() > 0)
                        {
                            respuesta = command.Parameters[parametrosalida].Value.ToString();
                        }
                        else { 
                            respuesta = "ERROR";
                        }
                        connection.Close();
                    }
                    return respuesta;
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
