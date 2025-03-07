using CLINICA_API.Areas.General.Helpers;
using CLINICA_API.Modelo;
using Dapper;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using static CLINICA_API.Areas.General.Helpers.ServiceConnection;

namespace CLINICA_API.Areas.Cita.Data
{
    public class PacienteData
    {
        private string urlws;
        //private readonly ServiceConnection _connection;
        public PacienteData(IConfiguration configuration/*ServiceConnection connection*/)
        {
            //_connection = connection;
            urlws = configuration.GetConnectionString("ConnecionSigeURLWS") + "Clinica/ServiceClinica.svc/";
        }

        WebClient cliente = new WebClient() { Encoding = Encoding.UTF8 };
        public MensajeJson ListarPacientexFiltro(string filtro)
        {
            var json = cliente.DownloadString(urlws + "paciente/listar_pacientexfiltro/" + filtro);
            var jsonobj = JsonConvert.DeserializeObject(json);
            return new MensajeJson("OK", jsonobj.ToString());
        }
        public MensajeJson ObtenerPacientexNumDocumento(string numdocumento)
        {
            var json = cliente.DownloadString(urlws + "paciente/obtener_pacientexnumdocumento/" + numdocumento);
            var jsonobj = JsonConvert.DeserializeObject(json);
            return new MensajeJson("OK", jsonobj.ToString());
        }
        public MensajeJson ObtenerPacientexIdPaciente(string idpaciente)
        {
            var json = cliente.DownloadString(urlws + "paciente/obtener_pacientexidpaciente/" + idpaciente);
            var jsonobj = JsonConvert.DeserializeObject(json);
            return new MensajeJson("OK", jsonobj.ToString());
        }
        public MensajeJson GuardarEditarPaciente(string jsonpaciente)
        {
            string jsonenviar = JsonConvert.SerializeObject(jsonpaciente);
            cliente.Headers["Content-Type"] = "application/json";
            var respuesta = cliente.UploadString(urlws + "paciente/registrar_paciente", "POST", jsonenviar);
            return new MensajeJson("OK", respuesta.ToString());
        }
    }
}
