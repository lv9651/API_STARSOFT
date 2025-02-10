using CLINICA_API.Areas.General.Service;
using Microsoft.AspNetCore.Mvc;

namespace CLINICA_API.Areas.General.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioPermisoController : ControllerBase
    {
        private readonly UsuarioPermisoService _service;
        public UsuarioPermisoController(UsuarioPermisoService service)
        {
            _service = service;
        }

        [HttpPost("GuardarEditarUsuarioPermiso")]
        public string GuardarEditarUsuarioPermiso([FromBody] string jsonusuariopermiso)
        {
            var rptaregistro = _service.GuardarEditarUsuarioPermiso(jsonusuariopermiso);
            return rptaregistro;
        }
        
    }
}
