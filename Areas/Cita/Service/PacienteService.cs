using CLINICA_API.Areas.Cita.Data;
using CLINICA_API.Areas.Medico.Data;
using Newtonsoft.Json;

namespace CLINICA_API.Areas.Cita.Service
{
    public class PacienteService
    {
        private readonly PacienteData _data;
        public PacienteService(PacienteData data)
        {
            _data = data;
        }

        public string ListarPacientexFiltro(string filtro)
        {
            return JsonConvert.SerializeObject(_data.ListarPacientexFiltro(filtro));
        }
        public string ObtenerPacientexNumDocumento(string numdocumento)
        {
            return JsonConvert.SerializeObject(_data.ObtenerPacientexNumDocumento(numdocumento));
        }
        public string ObtenerPacientexIdPaciente(string idpaciente)
        {
            return JsonConvert.SerializeObject(_data.ObtenerPacientexIdPaciente(idpaciente));
        }
        public string GuardarEditarPaciente(string jsonpaciente)
        {
            return JsonConvert.SerializeObject(_data.GuardarEditarPaciente(jsonpaciente));
        }
    }
}
