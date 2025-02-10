using CLINICA_API.Areas.Cita.Service;
using Microsoft.AspNetCore.Mvc;

namespace CLINICA_API.Areas.Cita.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcedenciaController : ControllerBase
    {
        private readonly ProcedenciaService _service;
        public ProcedenciaController(ProcedenciaService service)
        {
            _service = service;
        }

        [HttpGet("ListarProcedencia_Combo")]
        public string ListarProcedencia_Combo()
        {
            return _service.ListarProcedencia_Combo();
        }
    }
}
