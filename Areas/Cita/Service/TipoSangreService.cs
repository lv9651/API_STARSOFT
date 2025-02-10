using CLINICA_API.Areas.Cita.Data;
using Newtonsoft.Json;

namespace CLINICA_API.Areas.Cita.Service
{
    public class TipoSangreService
    {
        private readonly TipoSangreData _data;
        public TipoSangreService(TipoSangreData data)
        {
            _data = data;
        }
        public string ListarTipoSangre_Combo()
        {
            return JsonConvert.SerializeObject(_data.ListarTipoSangre_Combo());
        }
    }
}
