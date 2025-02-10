using CLINICA_API.Areas.General.Service;
using CLINICA_API.Areas.Medico.Service;
using Microsoft.AspNetCore.Mvc;

namespace CLINICA_API.Areas.General.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModalidadController : ControllerBase
    {
        private readonly ModalidadService _service;
        public ModalidadController(ModalidadService service)
        {
            _service = service;
        }
        [HttpGet("ListarModalidad_Combo")]
        public string ListarModalidad_Combo()
        {
            return _service.ListarModalidad_Combo();
        }
    }
}
