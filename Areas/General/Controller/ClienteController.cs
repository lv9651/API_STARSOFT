using CLINICA_API.Areas.General.Service;
using Microsoft.AspNetCore.Mvc;

namespace CLINICA_API.Areas.General.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteService _service;
        public ClienteController(ClienteService service)
        {
            _service = service;
        }

        [HttpGet("ObtenerClientexNumDocumento/{numdocumento}")]
        public string ObtenerClientexNumDocumento(string numdocumento)
        {
            return _service.ObtenerClientexNumDocumento(numdocumento);
        }
        [HttpPost("GuardarEditarCliente")]
        public string GuardarEditarCliente([FromBody] string jsoncliente)
        {
            var rptaregistro = _service.GuardarEditarCliente(jsoncliente);
            return rptaregistro;
        }
    }
}
