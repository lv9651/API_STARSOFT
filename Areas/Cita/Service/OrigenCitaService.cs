using CLINICA_API.Areas.Cita.Data;
using Newtonsoft.Json;

namespace CLINICA_API.Areas.Cita.Service
{
    public class OrigenCitaService
    {
        private readonly OrigenCitaData _data;
        public OrigenCitaService(OrigenCitaData data)
        {
            _data = data;
        }

        public string ListarOrigenCita_Combo()
        {
            return JsonConvert.SerializeObject(_data.ListarOrigenCita_Combo());
        }
    }
}
