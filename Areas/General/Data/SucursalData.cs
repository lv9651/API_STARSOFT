using CLINICA_API.Areas.General.Helpers;
using CLINICA_API.Modelo;
using Dapper;
using static CLINICA_API.Areas.General.Helpers.ServiceConnection;

namespace CLINICA_API.Areas.General.Data
{
    public class SucursalData
    {
        private readonly ServiceConnection _connection;
        public SucursalData(ServiceConnection connection)
        {
            _connection = connection;
        }
        public MensajeJson ListarSucursalxIdEmpresa_Combo(string idempresa)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@idempresa", idempresa);
            return _connection.MetodoDatatabletostringsql("Clinica.sp_listar_sucursalxidempresa_combo", parameters);
        }
        public MensajeJson ListarSucuralxFiltro(string filtro)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@filtro", filtro);
            return _connection.MetodoDatatabletostringsql("General.sp_listar_sucursalxfiltro", parameters);
        }
        public MensajeJson ObtenerSucursalxIdSucursal(string idsucursal)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@idsucursal", idsucursal);
            return _connection.MetodoDatatabletostringsql("General.sp_obtener_sucursalxidsucursal", parameters);
        }
        public MensajeJson GuardarEditarSucursal(string jsonsucursal)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@jsonsucursal", jsonsucursal);
            return _connection.MetodoRespuestasql("General.sp_guardareditar_sucursal", parameters, 50);
        }
        public MensajeJson GuardarEditarListaPrecioSucursal(string jsonlistapreciosucursal)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@jsonlistapreciosucursal", jsonlistapreciosucursal);
            return _connection.MetodoRespuestasql("Comercial.sp_guardareditar_listaprecio_sucursal", parameters, 50);
        }
        public MensajeJson GuardarEditarCorrelativoSucursal(string jsoncorrelativosucursal)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@jsoncorrelativosucursal", jsoncorrelativosucursal);
            return _connection.MetodoRespuestasql("General.sp_guardareditar_documentotributario_sucursal", parameters, 50);
        }
        public MensajeJson ListarCorrelativoxIdSucursal(string idsucursal)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@idsucursal", idsucursal);
            return _connection.MetodoDatatabletostringsql("General.sp_listar_documentotributario_sucursalxidsucursal", parameters);
        }
    }
}
