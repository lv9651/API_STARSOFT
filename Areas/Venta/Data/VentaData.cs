using CLINICA_API.Areas.General.Helpers;
using CLINICA_API.Modelo;
using Dapper;

namespace CLINICA_API.Areas.Venta.Data
{
    public class VentaData
    {
        private readonly ServiceConnection _connection;
        public VentaData(ServiceConnection connection)
        {
            _connection = connection;
        }

        public MensajeJson ObtenerDatosComprobantexIdVenta(string idventa)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@idventa", idventa);
            return _connection.MetodoDatatabletostringsql("Ventas.sp_obtener_datoscomprobantexidventa", parameters);
        }
        public MensajeJson ObtenerDatosVentaParaCompletarPagoxIdVenta(string idventa)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@idventa", idventa);
            return _connection.MetodoDatatabletostringsql("Ventas.sp_obtener_datosventaparacompletarpagoxidventa", parameters);
        }
        public MensajeJson GuardarEditarComplementoVentaPago(string jsonventapago)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@jsonventapago", jsonventapago);
            return _connection.MetodoRespuestasql("Ventas.sp_guardareditar_complementoventapago", parameters, 50);
        }
    }
}