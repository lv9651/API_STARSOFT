using CLINICA_API.Areas.Medico.Data;
using Newtonsoft.Json;

namespace CLINICA_API.Areas.Medico.Service
{
    public class EspecialidadService
    {
        private readonly EspecialidadData _data;
        public EspecialidadService(EspecialidadData data)
        {
            _data = data;
        }

        public string ListarEspecialidad_Combo()
        {
            return JsonConvert.SerializeObject(_data.ListarEspecialidad_Combo());
        }
    }
}
