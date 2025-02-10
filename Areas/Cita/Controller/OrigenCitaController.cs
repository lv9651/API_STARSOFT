using CLINICA_API.Areas.Cita.Service;
using Microsoft.AspNetCore.Mvc;

namespace CLINICA_API.Areas.Cita.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrigenCitaController : ControllerBase
    {
        private readonly OrigenCitaService _service;
        public OrigenCitaController(OrigenCitaService service)
        {
            _service = service;
        }

        [HttpGet("ListarOrigenCita_Combo")]
        public string ListarOrigenCita_Combo()
        {
            return _service.ListarOrigenCita_Combo();
        }
    }
}
