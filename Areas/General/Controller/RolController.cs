using CLINICA_API.Areas.General.Service;
using Microsoft.AspNetCore.Mvc;

namespace CLINICA_API.Areas.General.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly RolService _service;
        public RolController(RolService service)
        {
            _service = service;
        }

        [HttpGet("ListarRoles")]
        public async Task<string> ListarRoles(string filtro = "")
        {
            return await _service.ListarRoles(filtro);
        }
        [HttpGet("ObtenerRolxIdRol/{idrol}")]
        public string ObtenerRolxIdRol(string idrol)
        {
            return _service.ObtenerRolxIdRol(idrol);
        }
        [HttpPost("GuardarEditarRol")]
        public string GuardarEditarRol([FromBody] string jsonrol)
        {
            var rptaregistro = _service.GuardarEditarRol(jsonrol);
            return rptaregistro;
        }
    }
}
