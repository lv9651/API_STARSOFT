using CLINICA_API.Areas.Medico.Service;
using Microsoft.AspNetCore.Mvc;

namespace CLINICA_API.Areas.Medico.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class HorarioMedicoController : ControllerBase
    {
        private readonly HorarioMedicoService _service;
        public HorarioMedicoController(HorarioMedicoService service)
        {
            _service = service;
        }

        [HttpGet("ListarMedico_modalHorarioMedico")]
        public string ListarMedico_modalHorarioMedico(string filtro = "")
        {
            return _service.ListarMedico_modalHorarioMedico(filtro);
        }
        [HttpGet("ListarHorarioMedicoxIdMedico/{idmedico}")]
        public string ListarHorarioMedicoxIdMedico(string idmedico)
        {
            return _service.ListarHorarioMedicoxIdMedico(idmedico);
        }
        [HttpGet("ObtenerHorarioMedicoxIdHorarioMedico/{idhorariomedico}")]
        public string ObtenerHorarioMedicoxIdHorarioMedico(string idhorariomedico)
        {
            return _service.ObtenerHorarioMedicoxIdHorarioMedico(idhorariomedico);
        }
        [HttpPost("GuardarEditarHorarioMedico")]
        public string GuardarEditarHorarioMedico([FromBody] string jsonhorariomedico)
        {
            var rptaregistro = _service.GuardarEditarHorarioMedico(jsonhorariomedico);
            return rptaregistro;
        }
        [HttpGet("ListarHorarioMedicoDivididoxFechaxIdMedico_Combo/{fecha}/{idmodalidad}/{idsucursal}/{idmedico}")]
        public string ListarHorarioMedicoDivididoxFechaxIdMedico_Combo(string fecha, string idmodalidad, string idsucursal, string idmedico)
        {
            return _service.ListarHorarioMedicoDivididoxFechaxIdMedico_Combo(fecha, idmodalidad, idsucursal, idmedico);
        }
    }
}
