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
        public ClienteData(IConfiguration configuration)
        {
            urlws = configuration.GetConnectionString("ConnecionSigeURLWS") + "Clinica/ServiceClinica.svc/";
        }

        WebClient cliente = new WebClient() { Encoding = Encoding.UTF8 };
        public MensajeJson ObtenerClientexNumDocumento(string numdocumento)
        {
            var json = cliente.DownloadString(urlws + "cliente/obtener_clientexnumdocumento/" + numdocumento);
            var jsonobj = JsonConvert.DeserializeObject(json);
            return new MensajeJson("OK", jsonobj.ToString());
        }
        public MensajeJson GuardarEditarCliente(string jsoncliente)
        {
            string jsonenviar = JsonConvert.SerializeObject(jsoncliente);
            cliente.Headers["Content-Type"] = "application/json";
            var respuesta = cliente.UploadString(urlws + "cliente/registrar_cliente", "POST", jsonenviar);
            return new MensajeJson("OK", respuesta.ToString());
        }
        public MensajeJson ObtenerClientexIdCliente(string idcliente)
        {
            var json = cliente.DownloadString(urlws + "cliente/obtener_clientexidcliente/" + idcliente);
            var jsonobj = JsonConvert.DeserializeObject(json);
            return new MensajeJson("OK", jsonobj.ToString());
        }
    }
}
