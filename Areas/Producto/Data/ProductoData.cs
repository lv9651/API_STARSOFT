using CLINICA_API.Areas.General.Helpers;
using CLINICA_API.Modelo;
using Dapper;

namespace CLINICA_API.Areas.Producto.Data
{
    public class ProductoData
    {
        private readonly ServiceConnection _connection;
        public ProductoData(ServiceConnection connection)
        {
            _connection = connection;
        }
        
        public MensajeJson ListarProductoxFiltro(string filtro)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@filtro", filtro);
            return _connection.MetodoDatatabletostringsql("Producto.sp_listar_productoxfiltro", parameters);
        }
        public MensajeJson ObtenerProductoxIdProducto(string idproducto)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@idproducto", idproducto);
            return _connection.MetodoDatatabletostringsql("Producto.sp_obtener_productoxidproducto", parameters);
        }
        public MensajeJson GuardarEditarProducto(string jsonproducto)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@jsonproducto", jsonproducto);
            return _connection.MetodoRespuestasql("Producto.sp_guardareditar_producto", parameters, 50);
        }
        public MensajeJson GuardarEditarPrecioProducto(string jsonprecioproducto)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@jsonprecioproducto", jsonprecioproducto);
            return _connection.MetodoRespuestasql("Comercial.sp_guardareditar_precioproducto", parameters, 50);
        }
        public MensajeJson ListarProductos_Combo(string idsucursal, string idlistaprecio, string idtipoproducto)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@idsucursal", idsucursal);
            parameters.Add("@idlistaprecio", idlistaprecio);
            parameters.Add("@idtipoproducto", idtipoproducto);
            return _connection.MetodoDatatabletostringsql("Producto.sp_listar_producto_combo", parameters);
        }
        public MensajeJson ListarProductoXIdListaPrecioxIdTipoProducto_Combo(string idlistaprecio, string idtipoproducto)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@idlistaprecio", idlistaprecio);
            parameters.Add("@idtipoproducto", idtipoproducto);
            return _connection.MetodoDatatabletostringsql("Comercial.sp_listar_precioproductoxidlistaprecioxidtipoproducto_combo", parameters);
        }
        public MensajeJson ListarProductoXIdListaPrecioxIdTipoProducto_Modal(string idlistaprecio, string idtipoproducto, string descripcion)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@idlistaprecio", idlistaprecio);
            parameters.Add("@idtipoproducto", idtipoproducto);
            parameters.Add("@descripcion", descripcion);
            return _connection.MetodoDatatabletostringsql("Comercial.sp_listar_precioproductoxidlistaprecioxidtipoproducto_modal", parameters);
        }
    }
}
