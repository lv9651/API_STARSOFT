using Azure.Core;
using CLINICA_API.Areas.Medico.Service;
using CLINICA_API.Areas.Usuario.Service;
using CLINICA_API.Modelo;
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
        [HttpPost("ValidarCredenciales")]
        public string ValidarCredenciales([FromBody] string jsoncredenciales)
        {
            return _service.ValidarCredenciales(jsoncredenciales);
        }
        [HttpGet("ListarUsuarios")]
        public string ListarUsuarios(string filtro = "") {
            return _service.ListarUsuarios(filtro);
        }
        [HttpGet("ObtenerUsuarioxIdUsuario/{idusuario}")]
        public string ObtenerUsuarioxIdUsuario(string idusuario) {
            return _service.ObtenerUsuarioxIdUsuario(idusuario);
        }
        [HttpPost("GuardarEditarUsuario")]
        public string GuardarEditarUsuario([FromBody] string jsonuser)
        {
            var rptaregistro = _service.GuardarEditarUsuario(jsonuser);
            return rptaregistro;
        }
        [HttpGet("ListarRolParaUsuario")]
        public string ListarRolParaUsuario()
        {
            return _service.ListarRolParaUsuario();
        }
    }
}
