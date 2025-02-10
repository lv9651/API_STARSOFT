using CLINICA_API.Areas.General.Service;
using Microsoft.AspNetCore.Mvc;

namespace CLINICA_API.Areas.General.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultorioController : ControllerBase
    {
        private readonly ConsultorioService _service;
        public ConsultorioController(ConsultorioService service)
        {
            _service = service;
        }
        [HttpGet("ListarConsultorio_Combo")]
        public string ListarConsultorio_Combo()
        {
            return _service.ListarConsultorio_Combo();
        }
    }
}
