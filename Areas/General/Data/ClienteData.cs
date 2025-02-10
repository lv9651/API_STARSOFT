using CLINICA_API.Areas.General.Helpers;
using CLINICA_API.Modelo;
using Dapper;
using static CLINICA_API.Areas.General.Helpers.ServiceConnection;

namespace CLINICA_API.Areas.General.Data
{
    public class ClienteData
    {
        private readonly ServiceConnection _connection;
        public ClienteData(ServiceConnection connection)
        {
            _connection = connection;
        }

        public MensajeJson ObtenerClientexNumDocumento(string numdocumento)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@numdocumento", numdocumento);
            return _connection.MetodoDatatabletostringsql("Clinica.sp_obtener_clientexnumdocumento", parameters, TipoConexion.SIGE);
        }
        public MensajeJson GuardarEditarCliente(string jsoncliente)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@jsoncliente", jsoncliente);
            return _connection.MetodoRespuestasql("Clinica.sp_registrar_actualizar_cliente", parameters, 50, TipoConexion.SIGE);
        }
        public MensajeJson ObtenerClientexIdCliente(string idcliente)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@idcliente", idcliente);
            return _connection.MetodoDatatabletostringsql("Clinica.sp_obtener_clientexidcliente", parameters, TipoConexion.SIGE);
        }
    }
}
