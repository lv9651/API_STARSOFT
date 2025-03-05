using CLINICA_API.Areas.Producto.Service;
using Microsoft.AspNetCore.Mvc;

namespace CLINICA_API.Areas.Producto.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController
    {
        private readonly ProductoService _service;
        public ProductoController(ProductoService service)
        {
            _service = service;
        }

        [HttpGet("ListarProductoxFiltro")]
        public string ListarProductoxFiltro(string filtro = "")
        {
            return _service.ListarProductoxFiltro(filtro);
        }
        [HttpGet("ObtenerProductoxIdProducto/{idproducto}")]
        public string ObtenerProductoxIdProducto(string idproducto)
        {
            return _service.ObtenerProductoxIdProducto(idproducto);
        }
        [HttpPost("GuardarEditarProducto")]
        public string GuardarEditarProducto([FromBody] string jsonproducto)
        {
            var rptaregistro = _service.GuardarEditarProducto(jsonproducto);
            return rptaregistro;
        }
        [HttpPost("GuardarEditarPrecioProducto")]
        public string GuardarEditarPrecioProducto([FromBody] string jsonprecioproducto)
        {
            var rptaregistro = _service.GuardarEditarPrecioProducto(jsonprecioproducto);
            return rptaregistro;
        }
        [HttpGet("ListarProductos_Combo/{idsucursal}/{idlistaprecio}/{idtipoproducto}")]
        public string ListarProductos_Combo(string idsucursal, string idlistaprecio, string idtipoproducto)
        {
            return _service.ListarProductos_Combo(idsucursal, idlistaprecio, idtipoproducto);
        }
        [HttpGet("ListarProductoXIdListaPrecioxIdTipoProducto_Combo/{idlistaprecio}/{idtipoproducto}")]
        public string ListarProductoXIdListaPrecioxIdTipoProducto_Combo(string idlistaprecio, string idtipoproducto)
        {
            return _service.ListarProductoXIdListaPrecioxIdTipoProducto_Combo(idlistaprecio, idtipoproducto);
        }
        [HttpGet("ListarProductoXIdListaPrecioxIdTipoProducto_Modal")]
        public string ListarProductoXIdListaPrecioxIdTipoProducto_Modal(string idlistaprecio, string idtipoproducto, string descripcion = "")
        {
            return _service.ListarProductoXIdListaPrecioxIdTipoProducto_Modal(idlistaprecio, idtipoproducto, descripcion);
        }
    }
}
