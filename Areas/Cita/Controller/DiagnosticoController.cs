using CLINICA_API.Areas.Cita.Service;
using Microsoft.AspNetCore.Mvc;

namespace CLINICA_API.Areas.Cita.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiagnosticoController : ControllerBase
    {
        private readonly DiagnosticoService _service;
        public DiagnosticoController(DiagnosticoService service)
        {
            _service = service;
        }

        [HttpGet("ListarDiagnostico_Combo")]
        public string ListarDiagnostico_Combo()
        {
            return _service.ListarDiagnostico_Combo();
        }
        [HttpGet("ListarDiagnosticoxFiltro")]
        public string ListarDiagnosticoxFiltro(string filtro = "")
        {
            return _service.ListarDiagnosticoxFiltro(filtro);
        }
        [HttpGet("ObtenerDiagnosticoxIdDiagnostico/{iddiagnostico}")]
        public string ObtenerDiagnosticoxIdDiagnostico(string iddiagnostico)
        {
            return _service.ObtenerDiagnosticoxIdDiagnostico(iddiagnostico);
        }
        [HttpPost("GuardarEditarDiagnostico")]
        public string GuardarEditarDiagnostico([FromBody] string jsondiagnostico)
        {
            var rptaregistro = _service.GuardarEditarDiagnostico(jsondiagnostico);
            return rptaregistro;
        }
    }
}
