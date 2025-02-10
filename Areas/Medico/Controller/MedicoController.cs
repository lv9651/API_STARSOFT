using CLINICA_API.Areas.Medico.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace CLINICA_API.Areas.Medico.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoController : ControllerBase
    {
        private readonly MedicoService _service;
        public MedicoController(MedicoService service)
        {
            _service = service;
        }
        [HttpGet("ListarMedicos")]
        public string ListarMedicosxFiltro(string filtro = "") {
            return _service.ListarMedicosxFiltro(filtro);
        }
        [HttpGet("ObtenerMedicoxIdMedico/{idmedico}")]
        public string ObtenerMedicoxIdMedico(string idmedico) {
            return _service.ObtenerMedicoxIdMedico(idmedico);
        }
        [HttpPost("GuardarEditarMedico")]
        public string GuardarEditarMedico([FromBody] string jsonmedico)
        {
            var rptaregistro = _service.GuardarEditarMedico(jsonmedico);
            return rptaregistro;
        }
        [HttpGet("ListarMedicosDisponibles_Combo/{fecha}/{idespecialidad}/{idmodalidad}/{idsucursal}")]
        public string ListarMedicosDisponibles_Combo(string fecha, string idespecialidad, string idmodalidad, string idsucursal)
        {
            return _service.ListarMedicosDisponibles_Combo(fecha, idespecialidad, idmodalidad, idsucursal);
        }
        [HttpGet("ListarMedicos_Modal")]
        public string ListarMedicosxFiltro_Modal(string filtro = "")
        {
            return _service.ListarMedicosxFiltro_Modal(filtro);
        }
        [HttpGet("ObtenerMedicoxNumColegiatura/{numcolegiatura}")]
        public string ObtenerMedicoxNumColegiatura(string numcolegiatura)
        {
            return _service.ObtenerMedicoxNumColegiatura(numcolegiatura);
        }
    }
}
