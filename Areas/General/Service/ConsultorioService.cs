using CLINICA_API.Areas.General.Data;
using Newtonsoft.Json;

namespace CLINICA_API.Areas.General.Service
{
    public class ConsultorioService
    {
        private readonly ConsultorioData _data;
        public ConsultorioService(ConsultorioData data)
        {
            _data = data;
        }

        public string ListarConsultorio_Combo()
        {
            return JsonConvert.SerializeObject(_data.ListarConsultorio_Combo());
        }
    }
}
