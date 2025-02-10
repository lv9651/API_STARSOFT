using CLINICA_API.Areas.Cita.Data;
using Newtonsoft.Json;

namespace CLINICA_API.Areas.Cita.Service
{
    public class DiagnosticoService
    {
        private readonly DiagnosticoData _data;
        public DiagnosticoService(DiagnosticoData data)
        {
            _data = data;
        }
        public string ListarDiagnostico_Combo()
        {
            return JsonConvert.SerializeObject(_data.ListarDiagnostico_Combo());
        }
    }
}
