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
    }
}
