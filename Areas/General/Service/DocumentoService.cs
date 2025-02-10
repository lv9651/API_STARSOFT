using CLINICA_API.Areas.General.Data;
using CLINICA_API.Areas.Medico.Data;
using Newtonsoft.Json;

namespace CLINICA_API.Areas.General.Service
{
    public class DocumentoService
    {
        private readonly DocumentoData _data;
        public DocumentoService(DocumentoData data)
        {
            _data = data;
        }
        public string ListarDocumento_Combo()
        {
            return JsonConvert.SerializeObject(_data.ListarDocumento_Combo());
        }
    }
}
