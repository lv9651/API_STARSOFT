using CLINICA_API.Areas.General.Data;
using Newtonsoft.Json;

namespace CLINICA_API.Areas.General.Service
{
    public class MotivoEmisionService
    {
        private readonly MotivoEmisionData _data;
        public MotivoEmisionService(MotivoEmisionData data)
        {
            _data = data;
        }

        public async Task<string> ListarMotivoEmisionXFiltro(string filtro)
        {
            return JsonConvert.SerializeObject(await _data.ListarMotivoEmisionXFiltro(filtro));
        }
        public string ObtenerMotivoEmisionxIdMotivoEmision(string idmotivoemision)
        {
            return JsonConvert.SerializeObject(_data.ObtenerMotivoEmisionxIdMotivoEmision(idmotivoemision));
        }
        public string GuardarEditarDocumentoMotivoEmision(string jsonmotivoemision)
        {
            return JsonConvert.SerializeObject(_data.GuardarEditarDocumentoMotivoEmision(jsonmotivoemision));
        }
    }
}
