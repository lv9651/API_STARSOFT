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
        public string ListarDiagnosticoxFiltro(string filtro)
        {
            return JsonConvert.SerializeObject(_data.ListarDiagnosticoxFiltro(filtro));
        }
        public string ObtenerDiagnosticoxIdDiagnostico(string iddiagnostico)
        {
            return JsonConvert.SerializeObject(_data.ObtenerDiagnosticoxIdDiagnostico(iddiagnostico));
        }
        public string GuardarEditarDiagnostico(string jsondiagnostico)
        {
            return JsonConvert.SerializeObject(_data.GuardarEditarDiagnostico(jsondiagnostico));
        }
    }
}
