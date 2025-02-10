using CLINICA_API.Areas.Medico.Data;
using Newtonsoft.Json;

namespace CLINICA_API.Areas.Medico.Service
{
    public class HorarioMedicoService
    {
        private readonly HorarioMedicoData _data;
        public HorarioMedicoService(HorarioMedicoData data)
        {
            _data = data;
        }
        public string ListarMedico_modalHorarioMedico(string filtro)
        {
            return JsonConvert.SerializeObject(_data.ListarMedico_modalHorarioMedico(filtro));
        }
        public string ListarHorarioMedicoxIdMedico(string idmedico)
        {
            return JsonConvert.SerializeObject(_data.ListarHorarioMedicoxIdMedico(idmedico));
        }
        public string ObtenerHorarioMedicoxIdHorarioMedico(string idhorariomedico)
        {
            return JsonConvert.SerializeObject(_data.ObtenerHorarioMedicoxIdHorarioMedico(idhorariomedico));
        }
        public string GuardarEditarHorarioMedico(string jsonhorariomedico)
        {
            return JsonConvert.SerializeObject(_data.GuardarEditarHorarioMedico(jsonhorariomedico));
        }
        public string ListarHorarioMedicoDivididoxFechaxIdMedico_Combo(string fecha, string idmodalidad, string idsucursal, string idmedico)
        {
            return JsonConvert.SerializeObject(_data.ListarHorarioMedicoDivididoxFechaxIdMedico_Combo(fecha, idmodalidad, idsucursal, idmedico));
        }
    }
}
