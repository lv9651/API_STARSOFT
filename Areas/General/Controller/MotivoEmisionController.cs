using CLINICA_API.Areas.General.Service;
using Microsoft.AspNetCore.Mvc;

namespace CLINICA_API.Areas.General.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotivoEmisionController : ControllerBase
    {
        private readonly MotivoEmisionService _service;
        public MotivoEmisionController(MotivoEmisionService service)
        {
            _service = service;
        }

        [HttpGet("ListarMotivoEmisionXFiltro")]
        public async Task<string> ListarMotivoEmisionXFiltro(string filtro = "")
        {
            return await _service.ListarMotivoEmisionXFiltro(filtro);
        }
        [HttpGet("ObtenerMotivoEmisionxIdMotivoEmision/{idmotivoemision}")]
        public string ObtenerMotivoEmisionxIdMotivoEmision(string idmotivoemision)
        {
            return _service.ObtenerMotivoEmisionxIdMotivoEmision(idmotivoemision);
        }
        [HttpPost("GuardarEditarDocumentoMotivoEmision")]
        public string GuardarEditarDocumentoMotivoEmision([FromBody] string jsonmotivoemision)
        {
            var rptaregistro = _service.GuardarEditarDocumentoMotivoEmision(jsonmotivoemision);
            return rptaregistro;
        }
    }
}
