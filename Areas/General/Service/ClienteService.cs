using CLINICA_API.Areas.General.Data;
using Newtonsoft.Json;

namespace CLINICA_API.Areas.General.Service
{
    public class ClienteService
    {
        private readonly ClienteData _data;
        public ClienteService(ClienteData data)
        {
            _data = data;
        }

        public string ObtenerClientexNumDocumento(string numdocumento)
        {
            return JsonConvert.SerializeObject(_data.ObtenerClientexNumDocumento(numdocumento));
        }
        public string GuardarEditarCliente(string jsoncliente)
        {
            return JsonConvert.SerializeObject(_data.GuardarEditarCliente(jsoncliente));
        }
    }
}
