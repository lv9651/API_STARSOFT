using CLINICA_API.Areas.Cita.Data;
using Newtonsoft.Json;

namespace CLINICA_API.Areas.Cita.Service
{
    public class TipoEspecialidadService
    {
        private readonly TipoEspecialidadData _data;
        public TipoEspecialidadService(TipoEspecialidadData data)
        {
            _data = data;
        }

        public string ListarTipoEspecialidad_Combo()
        {
            return JsonConvert.SerializeObject(_data.ListarTipoEspecialidad_Combo());
        }
    }
}
