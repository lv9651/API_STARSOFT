using CLINICA_API.Areas.General.Service;
using Microsoft.AspNetCore.Mvc;

namespace CLINICA_API.Areas.General.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private readonly EmpresaService _service;
        public EmpresaController(EmpresaService service)
        {
            _service = service;
        }

        [HttpGet("ListarEmpresa_Combo")]
        public string ListarEmpresa_Combo()
        {
            return _service.ListarEmpresa_Combo();
        }
    }
}
