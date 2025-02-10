using CLINICA_API.Areas.General.Helpers;
using CLINICA_API.Modelo;
using Dapper;

namespace CLINICA_API.Areas.Comercial.Data
{
    public class ListaPreciosData
    {
        private readonly ServiceConnection _connection;
        public ListaPreciosData(ServiceConnection connection)
        {
            _connection = connection;
        }

        public MensajeJson ListarListaPrecioxFiltro(string filtro)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@filtro", filtro);
            return _connection.MetodoDatatabletostringsql("Comercial.sp_listar_listaprecioxfiltro", parameters);
        }
        public MensajeJson ObtenerListaPrecioxIdListaPrecio(string idlistaprecio)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@idlistaprecio", idlistaprecio);
            return _connection.MetodoDatatabletostringsql("Comercial.sp_obtener_listaprecioxidlistaprecio", parameters);
        }
        public MensajeJson GuardarEditarListaPrecio(string jsonlistaprecios)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@jsonlistaprecios", jsonlistaprecios);
            return _connection.MetodoRespuestasql("Comercial.sp_guardareditar_listaprecio", parameters, 50);
        }
        public MensajeJson ListarListaPrecioXIdSucursal_Combo(string idsucursal)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@idsucursal", idsucursal);
            return _connection.MetodoDatatabletostringsql("Comercial.sp_listar_listaprecioxidsucursal_combo", parameters);
        }
    }
}
