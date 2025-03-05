using CLINICA_API.Areas.Producto.Data;
using Newtonsoft.Json;

namespace CLINICA_API.Areas.Producto.Service
{
    public class ProductoService
    {
        private readonly ProductoData _data;
        public ProductoService(ProductoData data)
        {
            _data = data;
        }

        public string ListarProductoxFiltro(string filtro)
        {
            return JsonConvert.SerializeObject(_data.ListarProductoxFiltro(filtro));
        }
        public string ObtenerProductoxIdProducto(string idproducto)
        {
            return JsonConvert.SerializeObject(_data.ObtenerProductoxIdProducto(idproducto));
        }
        public string GuardarEditarProducto(string jsonproducto)
        {
            return JsonConvert.SerializeObject(_data.GuardarEditarProducto(jsonproducto));
        }
        public string GuardarEditarPrecioProducto(string jsonprecioproducto)
        {
            return JsonConvert.SerializeObject(_data.GuardarEditarPrecioProducto(jsonprecioproducto));
        }
        public string ListarProductos_Combo(string idsucursal, string idlistaprecio, string idtipoproducto)
        {
            return JsonConvert.SerializeObject(_data.ListarProductos_Combo(idsucursal, idlistaprecio, idtipoproducto));
        }
        public string ListarProductoXIdListaPrecioxIdTipoProducto_Combo(string idlistaprecio, string idtipoproducto)
        {
            return JsonConvert.SerializeObject(_data.ListarProductoXIdListaPrecioxIdTipoProducto_Combo(idlistaprecio, idtipoproducto));
        }
        public string ListarProductoXIdListaPrecioxIdTipoProducto_Modal(string idlistaprecio, string idtipoproducto, string descripcion)
        {
            return JsonConvert.SerializeObject(_data.ListarProductoXIdListaPrecioxIdTipoProducto_Modal(idlistaprecio, idtipoproducto, descripcion));
        }
    }
}
