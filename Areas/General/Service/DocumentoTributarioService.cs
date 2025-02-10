using CLINICA_API.Areas.General.Data;
using Newtonsoft.Json;

namespace CLINICA_API.Areas.General.Service
{
    public class DocumentoTributarioService
    {
        private readonly DocumentoTributarioData _data;
        public DocumentoTributarioService(DocumentoTributarioData data)
        {
            _data = data;
        }
        public string ListarDocumentoTributario_Combo()
        {
            return JsonConvert.SerializeObject(_data.ListarDocumentoTributario_Combo());
        }
        public string ListarDocumentoTributarioxIdSucursalxCobro_Combo(string idsucursal)
        {
            return JsonConvert.SerializeObject(_data.ListarDocumentoTributarioxIdSucursalxCobro_Combo(idsucursal));
        }
        public async Task<string> ListarDocumentoTributarioXFiltro(string filtro)
        {
            return JsonConvert.SerializeObject(await _data.ListarDocumentoTributarioXFiltro(filtro));
        }
        public string ObtenerDocumentoTributarioxIdDocumentoTributario(string iddocumentotributario)
        {
            return JsonConvert.SerializeObject(_data.ObtenerDocumentoTributarioxIdDocumentoTributario(iddocumentotributario));
        }
        public string GuardarEditarDocumentoTributario(string jsondocumentotributario)
        {
            return JsonConvert.SerializeObject(_data.GuardarEditarDocumentoTributario(jsondocumentotributario));
        }
        public string ListarMotivoEmisionDocumentoTributarioxIdDocumentoTributario(string iddocumentotributario)
        {
            return JsonConvert.SerializeObject(_data.ListarMotivoEmisionDocumentoTributarioxIdDocumentoTributario(iddocumentotributario));
        }
        public string GuardarEditarMotivoEmisionDocumentoTributario(string jsonmotivoemisiondocumentotributario)
        {
            return JsonConvert.SerializeObject(_data.GuardarEditarMotivoEmisionDocumentoTributario(jsonmotivoemisiondocumentotributario));
        }
    }
}
