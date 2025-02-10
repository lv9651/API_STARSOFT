using CLINICA_API.Areas.Producto.Service;
using Microsoft.AspNetCore.Mvc;

namespace CLINICA_API.Areas.Producto.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoProductoController : ControllerBase
    {
        private readonly TipoProductoService _service;
        public TipoProductoController(TipoProductoService service)
        {
            _service = service;
        }

        
        [HttpGet("ListarTipoProductoxFiltro")]
        public string ListarTipoProductoxFiltro(string filtro = "")
        {
            return _service.ListarTipoProductoxFiltro(filtro);
        }
        [HttpGet("ObtenerTipoProductoxIdTipoProducto/{idtipoproducto}")]
        public string ObtenerTipoProductoxIdTipoProducto(string idtipoproducto)
        {
            return _service.ObtenerTipoProductoxIdTipoProducto(idtipoproducto);
        }
        [HttpPost("GuardarEditarTipoProducto")]
        public string GuardarEditarTipoProducto([FromBody] string jsontipoproducto)
        {
            var rptaregistro = _service.GuardarEditarTipoProducto(jsontipoproducto);
            return rptaregistro;
        }
        [HttpGet("ListarTipoProducto_Combo")]
        public string ListarTipoProducto_Combo()
        {
            return _service.ListarTipoProducto_Combo();
        }
    }
}
