using CLINICA_API.Areas.General.Helpers;
using CLINICA_API.Modelo;
using Dapper;

namespace CLINICA_API.Areas.Producto.Data
{
    public class TipoProductoData
    {
        private readonly ServiceConnection _connection;
        public TipoProductoData(ServiceConnection connection)
        {
            _connection = connection;
        }
        
        public MensajeJson ListarTipoProductoxFiltro(string filtro)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@filtro", filtro);
            return _connection.MetodoDatatabletostringsql("Producto.sp_listar_tipoproductoxfiltro", parameters);
        }
        public MensajeJson ObtenerTipoProductoxIdTipoProducto(string idtipoproducto)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@idtipoproducto", idtipoproducto);
            return _connection.MetodoDatatabletostringsql("Producto.sp_obtener_tipoproductoxidtipoproducto", parameters);
        }
        public MensajeJson GuardarEditarTipoProducto(string jsontipoproducto)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@jsontipoproducto", jsontipoproducto);
            return _connection.MetodoRespuestasql("Producto.sp_guardareditar_tipoproducto", parameters, 50);
        }
        public MensajeJson ListarTipoProducto_Combo()
        {
            var parameters = new DynamicParameters();
            return _connection.MetodoDatatabletostringsql("Producto.sp_listar_tipoproducto_combo", parameters);
        }
    }
}
