using CLINICA_API.Areas.Cita.Service;
using Microsoft.AspNetCore.Mvc;

namespace CLINICA_API.Areas.Cita.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoSangreController : ControllerBase
    {
        private readonly TipoSangreService _service;
        public TipoSangreController(TipoSangreService service)
        {
            _service = service;
        }

        [HttpGet("ListarTipoSangre_Combo")]
        public string ListarTipoSangre_Combo()
        {
            return _service.ListarTipoSangre_Combo();
        }
    }
}
