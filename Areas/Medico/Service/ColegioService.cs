using CLINICA_API.Areas.Medico.Data;
using CLINICA_API.Areas.Usuario.Data;
using Newtonsoft.Json;

namespace CLINICA_API.Areas.Medico.Service
{
    public class ColegioService
    {
        private readonly ColegioData _data;
        public ColegioService(ColegioData data)
        {
            _data = data;
        }

        public string ListarColegio_Combo()
        {
            return JsonConvert.SerializeObject(_data.ListarColegio_Combo());
        }
    }
}
