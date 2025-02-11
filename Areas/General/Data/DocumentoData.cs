using CLINICA_API.Areas.General.Helpers;
using CLINICA_API.Modelo;
using Dapper;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using static CLINICA_API.Areas.General.Helpers.ServiceConnection;

namespace CLINICA_API.Areas.General.Data
{
    public class DocumentoData
    {
        private string urlws;
        //private readonly ServiceConnection _connection;
        public DocumentoData(IConfiguration configuration/*ServiceConnection connection*/)
        {
            //_connection = connection;
            urlws = configuration.GetConnectionString("ConnecionSigeURLWS") + "Clinica/ServiceClinica.svc/";
        }

        WebClient cliente = new WebClient() { Encoding = Encoding.UTF8 };
        public MensajeJson ListarDocumento_Combo()
        {
            var json = cliente.DownloadString(urlws + "documento/listar_documento_combo");
            var jsonobj = JsonConvert.DeserializeObject(json);
            return new MensajeJson("OK", jsonobj.ToString());
            //var parameters = new DynamicParameters();
            //return _connection.MetodoDatatabletostringsql("Clinica.sp_listar_documento_combo", parameters , TipoConexion.SIGE);
        }
    }
}
