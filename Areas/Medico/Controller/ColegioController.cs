using CLINICA_API.Areas.Medico.Service;
using Microsoft.AspNetCore.Mvc;

namespace CLINICA_API.Areas.Medico.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColegioController : ControllerBase
    {
        private readonly ColegioService _service;
        public ColegioController(ColegioService service)
        {
            _service = service;
        }

        [HttpGet("ListarColegio_Combo")]
        public string ListarColegio_Combo()
        {
            return _service.ListarColegio_Combo();
        }
    }
}
