using CLINICA_API.Areas.General.Service;
using Microsoft.AspNetCore.Mvc;

namespace CLINICA_API.Areas.General.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolPermisoController : ControllerBase
    {
        private readonly RolPermisoService _service;
        public RolPermisoController(RolPermisoService service)
        {
            _service = service;
        }

        [HttpPost("GuardarEditarRolPermiso")]
        public string GuardarEditarRolPermiso([FromBody] string jsonrolpermiso)
        {
            var rptaregistro = _service.GuardarEditarRolPermiso(jsonrolpermiso);
            return rptaregistro;
        }
    }
}
