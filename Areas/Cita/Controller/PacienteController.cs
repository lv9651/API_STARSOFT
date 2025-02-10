using CLINICA_API.Areas.Cita.Service;
using Microsoft.AspNetCore.Mvc;

namespace CLINICA_API.Areas.Cita.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly PacienteService _service;
        public PacienteController(PacienteService service)
        {
            _service = service;
        }

        [HttpGet("ListarPacientexFiltro")]
        public string ListarPacientexFiltro(string filtro = "")
        {
            return _service.ListarPacientexFiltro(filtro);
        }
        [HttpGet("ObtenerPacientexNumDocumento/{numdocumento}")]
        public string ObtenerPacientexNumDocumento(string numdocumento)
        {
            return _service.ObtenerPacientexNumDocumento(numdocumento);
        }
        [HttpPost("GuardarEditarPaciente")]
        public string GuardarEditarPaciente([FromBody] string jsonpaciente)
        {
            var rptaregistro = _service.GuardarEditarPaciente(jsonpaciente);
            return rptaregistro;
        }
        [HttpGet("ObtenerPacientexIdPaciente/{idpaciente}")]
        public string ObtenerPacientexIdPaciente(string idpaciente)
        {
            return _service.ObtenerPacientexIdPaciente(idpaciente);
        }
    }
}
