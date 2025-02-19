using CLINICA_API.Areas.General.Helpers;
using CLINICA_API.Modelo;
using Dapper;

namespace CLINICA_API.Areas.Venta.Data
{
    public class NotaCreditoData
    {
        private readonly ServiceConnection _connection;
        public NotaCreditoData(ServiceConnection connection)
        {
            _connection = connection;
        }

        public async Task<MensajeJson> ListarNotaCreditoXFiltro(string fechainicio, string fechafin, string filtro)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@fechainicio", fechainicio);
            parameters.Add("@fechafin", fechafin);
            parameters.Add("@filtro", filtro);
            return await _connection.MetodoDatatabletostringsqlasync("Ventas.sp_listar_notacreditoxfiltro", parameters);
        }
        public MensajeJson ObtenerNotaCreditoxIdNotaCredito(string idnota)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@idnota", idnota);
            return _connection.MetodoDatatabletostringsql("Ventas.sp_obtener_notacreditoxidnota", parameters);
        }
        public MensajeJson GuardarEditarNotaCredito(string jsonnotacredito)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@jsonnotacredito", jsonnotacredito);
            return _connection.MetodoRespuestasql("Ventas.sp_guardareditar_notacredito", parameters, 50);
        }
        public MensajeJson ObtenerDatosComprobantexIdNotaCredito(string idnota)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@idnota", idnota);
            return _connection.MetodoDatatabletostringsql("Ventas.sp_obtener_datoscomprobantexidnota", parameters);
        }
    }
}
