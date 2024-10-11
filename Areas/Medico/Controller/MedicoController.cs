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
        public string GetListaMedicos(string filtro = "") {
            return _service.GetListaMedicos(filtro);
        }
        [HttpGet("Medicoxid/{idmedico}")]
        public string GetMedicoxid(string idmedico) {
            return _service.GetMedicoxid(idmedico);
        }
        [HttpGet("ListasGenerales")]
        public async Task<string> GetListasGenerales() {
            return await _service.GetListasGenerales();
        }
        [HttpPost("GuardarEditar")]
        public string GuardarEditar([FromBody] string jsonmedico) {
            var rptaregistro=_service.GuardarEditar(jsonmedico);
            return rptaregistro;
        }
    }
}
