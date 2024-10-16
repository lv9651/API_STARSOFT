using Azure.Core;
using CLINICA_API.Areas.Medico.Service;
using CLINICA_API.Areas.Usuario.Service;
using Microsoft.AspNetCore.Mvc;

namespace CLINICA_API.Areas.Usuario.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _service;
        public UsuarioController(UsuarioService service)
        {
            _service = service;
        }
        [HttpGet("GetValLogin/{username}/{clave}")]
        public string GetValLogin(string username, string clave)
        {
            return _service.GetValLogin(username, clave);
        }
        [HttpGet("GetListaUsuario")]
        public string GetListaUsuario(string filtro = "") {
            return _service.GetListaUsuario(filtro);
        }
        [HttpGet("Usuarioxid/{idusuario}")]
        public string GetUsuarioxid(string idusuario) {
            return _service.GetUsuarioxid(idusuario);
        }
        [HttpPost("GuardarEditar")]
        public string GuardarEditar([FromBody] string jsonuser)
        {
            var rptaregistro = _service.GuardarEditar(jsonuser);
            return rptaregistro;
        }
        [HttpGet("GetPermisosxUsuarioxRol/{idusuario}/{idrol}")]
        public string GetPermisosxUsuarioxRol(string idusuario, string idrol) {
            return _service.GetPermisosxUsuarioxRol(idusuario, idrol);
        }
        [HttpGet("ActualizarPermisoxUsuario/{idusuario}/{idpermiso}")]
        public string ActualizarPermisoxUsuario(string idusuario, string idpermiso) { 
            return _service.ActualizarPermisoxUsuario(idusuario, idpermiso);
        }
    }
}
