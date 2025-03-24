using Dapper;
using System.Data;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authentication.Cookies;
using CLINICA_API.Modelo;


namespace CLINICA_API.Areas.General.Helpers
{
    public class ServiceConnection
    {
        private readonly string? _connection;
        private readonly string? _connectionSislab;
        public enum TipoConexion
        {
            Clinica,
            SISLAB
        }
        public ServiceConnection(IConfiguration configuration) {
            _connection = configuration.GetConnectionString("ConnectionClinica");
            _connectionSislab = configuration.GetConnectionString("ConnectionSislab");
        }
        //Metodo que retorna una tabla
        public MensajeJson MetodoDatatabletostringsql(string procedimiento, DynamicParameters parametros, TipoConexion tipoConexion = TipoConexion.Clinica)
        {                                                                               
            try
            {
                string conexion = _connection;
                
                if (tipoConexion == TipoConexion.SISLAB)
                    conexion = _connectionSislab;

                using (var connection = new SqlConnection(conexion))
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
                    return new MensajeJson("OK", JsonConvert.SerializeObject(datatable));
                }
            }
            catch (Exception ex)
            {
                // Manejar excepciones
                return new MensajeJson("ERROR", ex.Message);
            }
        }
        //Metodo que retorna un output
        public MensajeJson MetodoRespuestasql(string procedimiento,DynamicParameters parametros,int sizeParametroSalida, TipoConexion tipoConexion = TipoConexion.Clinica)
        {
            try
            {
                string parametrosalida = "@respuesta";
                string respuesta = "";
                string sEstado = "";
                string conexion = _connection;

                if (tipoConexion == TipoConexion.SISLAB)
                    conexion = _connectionSislab;
                
                using (var connection = new SqlConnection(conexion))
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
                            sEstado = "OK";
                        else
                            sEstado = "WARNING";
                        respuesta = command.Parameters[parametrosalida].Value.ToString();
                        connection.Close();
                    }
                    return new MensajeJson(sEstado, respuesta);
                }
            }
            catch (Exception vEx)
            {
                // Manejar excepciones
                return new MensajeJson("ERROR", vEx.Message);
            }
        }
        //Metodo que te da una respuesta en caso se haya ejecutado algun registro
        public MensajeJson MetodoRespuestasql(string procedimiento, DynamicParameters parametros)
        {
            try
            {
                string respuesta = "";
                using (var connection = new SqlConnection(_connection))
                {
                    using (var command = new SqlCommand(procedimiento, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        if (parametros is not null)
                        {
                            foreach (var param in parametros.ParameterNames)
                            {
                                command.Parameters.AddWithValue(param, parametros.Get<dynamic>(param));
                            }
                        }
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                    return new MensajeJson("OK", respuesta);
                }
            }
            catch (Exception vEx)
            {
                // Manejar excepciones
                return new MensajeJson("ERROR", vEx.Message);
            }
        }
        //Metodo que te retorna una tabla de manera asincrona
        public async Task<MensajeJson> MetodoDatatabletostringsqlasync(string procedimiento, DynamicParameters parametros, TipoConexion tipoConexion = TipoConexion.Clinica)
        {
            try
            {
                string conexion = _connection;
                
                if (tipoConexion == TipoConexion.SISLAB)
                    conexion = _connectionSislab;

                using (var connection = new SqlConnection(conexion))
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
                    return new MensajeJson("OK", JsonConvert.SerializeObject(datatable));
                }
            }
            catch (Exception ex)
            {
                // Manejar excepciones
                return new MensajeJson("ERROR", ex.Message);
            }
        }

    }
}
