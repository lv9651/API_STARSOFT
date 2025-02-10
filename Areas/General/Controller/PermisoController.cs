using CLINICA_API.Areas.General.Service;
using Microsoft.AspNetCore.Mvc;

namespace CLINICA_API.Areas.General.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermisoController : ControllerBase
    {
        private readonly PermisoService _service;
        public PermisoController(PermisoService service)
        {
            _service = service;
        }

        [HttpGet("ListarPermisosxIdUsuario/{idusuario}")]
        public string ListarPermisosxIdUsuario(string idusuario)
        {
            return _service.ListarPermisosxIdUsuario(idusuario);
        }
        [HttpGet("ListarPermisosxIdRol/{idrol}")]
        public string ListarPermisosxIdRol(string idrol)
        {
            return _service.ListarPermisosxIdRol(idrol);
        }
    }
}
