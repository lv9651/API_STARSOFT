using CLINICA_API.Areas.Medico.Service;
using Microsoft.AspNetCore.Mvc;

namespace CLINICA_API.Areas.Medico.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspecialidadController : ControllerBase
    {
        private readonly EspecialidadService _service;
        public EspecialidadController(EspecialidadService service)
        {
            _service = service;
        }

        [HttpGet("ListarEspecialidad_Combo")]
        public string ListarEspecialidad_Combo()
        {
            return _service.ListarEspecialidad_Combo();
        }
    }
}
