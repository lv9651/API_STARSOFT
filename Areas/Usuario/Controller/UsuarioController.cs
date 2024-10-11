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
        public string GetValLogin(string username,string clave)
        {
            return _service.GetValLogin(username,clave);
        }
    }
}
