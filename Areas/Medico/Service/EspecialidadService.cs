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
        public async Task<string> ListarEspecialidadXFiltro(string filtro)
        {
            return JsonConvert.SerializeObject(await _data.ListarEspecialidadXFiltro(filtro));
        }
        public string ObtenerEspecialidadxIdEspecialidad(string idespecialidad)
        {
            return JsonConvert.SerializeObject(_data.ObtenerEspecialidadxIdEspecialidad(idespecialidad));
        }
        public string GuardarEditarEspecialidad(string jsonespecialidad)
        {
            return JsonConvert.SerializeObject(_data.GuardarEditarEspecialidad(jsonespecialidad));
        }
    }
}
