using CLINICA_API.Areas.Cita.Service;
using Microsoft.AspNetCore.Mvc;

namespace CLINICA_API.Areas.Cita.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoEspecialidadController : ControllerBase
    {
        private readonly TipoEspecialidadService _service;
        public TipoEspecialidadController(TipoEspecialidadService service)
        {
            _service = service;
        }

        [HttpGet("ListarTipoEspecialidad_Combo")]
        public string ListarTipoEspecialidad_Combo()
        {
            return _service.ListarTipoEspecialidad_Combo();
        }
    }
}
