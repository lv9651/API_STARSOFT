using CLINICA_API.Areas.General.Service;
using Microsoft.AspNetCore.Mvc;

namespace CLINICA_API.Areas.General.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentoTributarioController : ControllerBase
    {
        private readonly DocumentoTributarioService _service;
        public DocumentoTributarioController(DocumentoTributarioService service)
        {
            _service = service;
        }

        [HttpGet("ListarDocumentoTributario_Combo")]
        public string ListarDocumentoTributario_Combo()
        {
            return _service.ListarDocumentoTributario_Combo();
        }
        [HttpGet("ListarDocumentoTributarioxIdSucursalxCobro_Combo/{idsucursal}")]
        public string ListarDocumentoTributarioxIdSucursalxCobro_Combo(string idsucursal)
        {
            return _service.ListarDocumentoTributarioxIdSucursalxCobro_Combo(idsucursal);
        }
        [HttpGet("ListarDocumentoTributarioXFiltro")]
        public async Task<string> ListarDocumentoTributarioXFiltro(string filtro = "")
        {
            return await _service.ListarDocumentoTributarioXFiltro(filtro);
        }
        [HttpGet("ObtenerDocumentoTributarioxIdDocumentoTributario/{iddocumentotributario}")]
        public string ObtenerDocumentoTributarioxIdDocumentoTributario(string iddocumentotributario)
        {
            return _service.ObtenerDocumentoTributarioxIdDocumentoTributario(iddocumentotributario);
        }
        [HttpPost("GuardarEditarDocumentoTributario")]
        public string GuardarEditarDocumentoTributario([FromBody] string jsondocumentotributario)
        {
            var rptaregistro = _service.GuardarEditarDocumentoTributario(jsondocumentotributario);
            return rptaregistro;
        }
        [HttpGet("ListarMotivoEmisionDocumentoTributarioxIdDocumentoTributario/{iddocumentotributario}")]
        public string ListarMotivoEmisionDocumentoTributarioxIdDocumentoTributario(string iddocumentotributario)
        {
            return _service.ListarMotivoEmisionDocumentoTributarioxIdDocumentoTributario(iddocumentotributario);
        }
        [HttpPost("GuardarEditarMotivoEmisionDocumentoTributario")]
        public string GuardarEditarMotivoEmisionDocumentoTributario([FromBody] string jsonmotivoemisiondocumentotributario)
        {
            var rptaregistro = _service.GuardarEditarMotivoEmisionDocumentoTributario(jsonmotivoemisiondocumentotributario);
            return rptaregistro;
        }
        [HttpGet("ListarDocumentoTributarioNC_Combo")]
        public string ListarDocumentoTributarioNC_Combo()
        {
            return _service.ListarDocumentoTributarioNC_Combo();
        }
    }
}
