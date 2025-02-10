using CLINICA_API.Areas.General.Helpers;
using CLINICA_API.Modelo;
using Dapper;
using Newtonsoft.Json;
using System.Data;
using System.Net;
using System.Text;
using static CLINICA_API.Areas.General.Helpers.ServiceConnection;

namespace CLINICA_API.Areas.General.Data
{
    public class ClienteData
    {
        private string urlws;
        //private readonly ServiceConnection _connection;
        public ClienteData(IConfiguration configuration/*ServiceConnection connection*/)
        {
            //_connection = connection;
            urlws = configuration.GetConnectionString("ConnecionSigeURLWS") + "Clinica/ServiceClinica.svc/";
        }

        WebClient cliente = new WebClient() { Encoding = Encoding.UTF8 };
        public MensajeJson ObtenerClientexNumDocumento(string numdocumento)
        {
            var json = cliente.DownloadString(urlws + "cliente/obtener_clientexnumdocumento/" + numdocumento);
            var jsonobj = JsonConvert.DeserializeObject(json);
            return new MensajeJson("OK", jsonobj.ToString());
            //var parameters = new DynamicParameters();
            //parameters.Add("@numdocumento", numdocumento);
            //return _connection.MetodoDatatabletostringsql("Clinica.sp_obtener_clientexnumdocumento", parameters, TipoConexion.SIGE);
        }
        public MensajeJson GuardarEditarCliente(string jsoncliente)
        {
            string jsonenviar = JsonConvert.SerializeObject(jsoncliente);
            cliente.Headers["Content-Type"] = "application/json";
            var respuesta = cliente.UploadString(urlws + "cliente/registrar_cliente", "POST", jsonenviar);
            return new MensajeJson("OK", respuesta.ToString());
            //var parameters = new DynamicParameters();
            //parameters.Add("@jsoncliente", jsoncliente);
            //return _connection.MetodoRespuestasql("Clinica.sp_registrar_actualizar_cliente", parameters, 50, TipoConexion.SIGE);
        }
        public MensajeJson ObtenerClientexIdCliente(string idcliente)
        {
            var json = cliente.DownloadString(urlws + "cliente/obtener_clientexidcliente/" + idcliente);
            var jsonobj = JsonConvert.DeserializeObject(json);
            return new MensajeJson("OK", jsonobj.ToString());
            //var parameters = new DynamicParameters();
            //parameters.Add("@idcliente", idcliente);
            //return _connection.MetodoDatatabletostringsql("Clinica.sp_obtener_clientexidcliente", parameters, TipoConexion.SIGE);
        }
    }
}
