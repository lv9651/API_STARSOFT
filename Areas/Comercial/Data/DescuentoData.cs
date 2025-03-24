using CLINICA_API.Areas.General.Helpers;
using CLINICA_API.Modelo;
using Dapper;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace CLINICA_API.Areas.Comercial.Data
{
    public class DescuentoData
    {
        private readonly ServiceConnection _connection;
        private string urlws;
        public DescuentoData(ServiceConnection connection, IConfiguration configuration)
        {
            _connection = connection;
            urlws = configuration.GetConnectionString("ConnecionSigeURLWS") + "Clinica/ServiceClinica.svc/";
        }
        WebClient cliente = new WebClient() { Encoding = Encoding.UTF8 };


        public MensajeJson ListarDescuentoxFiltro(string fechainicio, string fechafin, string filtro)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@fechainicio", fechainicio);
            parameters.Add("@fechafin", fechafin);
            parameters.Add("@filtro", filtro);
            return _connection.MetodoDatatabletostringsql("Comercial.sp_listar_descuentoxfiltro", parameters);
        }
        public MensajeJson ListarSucursalxFiltro_Modal(string filtro)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@filtro", filtro);
            return _connection.MetodoDatatabletostringsql("Comercial.sp_listar_sucursal_modal_descuento", parameters);
        }
        public MensajeJson ListarListaPrecioxFiltro_Modal(string filtro)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@filtro", filtro);
            return _connection.MetodoDatatabletostringsql("Comercial.sp_listar_listaprecio_modal_descuento", parameters);
        }
        public MensajeJson ListarTipoProductoxFiltro_Modal(string filtro)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@filtro", filtro);
            return _connection.MetodoDatatabletostringsql("Comercial.sp_listar_tipoproducto_modal_descuento", parameters);
        }
        public MensajeJson ListarProductoxFiltro_Modal(string filtro)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@filtro", filtro);
            return _connection.MetodoDatatabletostringsql("Comercial.sp_listar_producto_modal_descuento", parameters);
        }
        public MensajeJson ListarClientexFiltro_Modal(string filtro)
        {
            var json = cliente.DownloadString(urlws + "cliente/listar_clientexfiltro?filtro=" + filtro);
            var jsonobj = JsonConvert.DeserializeObject(json);
            return new MensajeJson("OK", jsonobj.ToString());
        }
        public MensajeJson ListarTipoDescuento_Combo()
        {
            var parameters = new DynamicParameters();
            return _connection.MetodoDatatabletostringsql("Comercial.sp_listar_tipodescuento_combo", parameters);
        }
        public MensajeJson GuardarEditarDescuento(string jsondescuento)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@jsondescuento", jsondescuento);
            return _connection.MetodoRespuestasql("Comercial.sp_guardareditar_descuento", parameters, 50);
        }
        public MensajeJson ObtenerDescuentoxIdDescuento(string iddescuento)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@iddescuento", iddescuento);
            return _connection.MetodoDatatabletostringsql("Comercial.sp_obtener_descuentoxiddescuento", parameters);
        }
        public MensajeJson EliminarDescuento(string iddescuento)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@iddescuento", iddescuento);
            return _connection.MetodoRespuestasql("Comercial.sp_eliminar_descuento", parameters, 50);
        }
        public MensajeJson ObtenerDescuentoParaVenta(string idsucursal, string idlistaprecio)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@idsucursal", idsucursal);
            parameters.Add("@idlistaprecio", idlistaprecio);
            return _connection.MetodoDatatabletostringsql("Comercial.sp_obtener_descuentoparaventa", parameters);
        }
    }
}
