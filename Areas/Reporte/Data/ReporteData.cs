using CLINICA_API.Areas.General.Helpers;
using CLINICA_API.Modelo;
using Dapper;

namespace CLINICA_API.Areas.Reporte.Data
{
    public class ReporteData
    {
        private readonly ServiceConnection _connection;
        public ReporteData(ServiceConnection connection)
        {
            _connection = connection;
        }

        public MensajeJson ListarCuadreCaja(string idusuario, string idsucursal, string fecha)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@idusuario", idusuario);
            parameters.Add("@idsucursal", idsucursal);
            parameters.Add("@fecha", fecha);
            return _connection.MetodoDatatabletostringsql("Reporte.sp_listar_cuadrecaja", parameters);
        }
        public MensajeJson ListarProcedimiento(string fechainicio, string fechafin, string idsucursal)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@fechainicio", fechainicio);
            parameters.Add("@fechafin", fechafin);
            parameters.Add("@idsucursal", idsucursal);
            return _connection.MetodoDatatabletostringsql("Reporte.sp_listar_procedimientoxfiltro", parameters);
        }
        public MensajeJson ListarNumeroConsultas(string fechainicio, string fechafin, string idmedico)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@fechainicio", fechainicio);
            parameters.Add("@fechafin", fechafin);
            parameters.Add("@idmedico", idmedico);
            return _connection.MetodoDatatabletostringsql("Reporte.sp_listar_nroconsultas", parameters);
        }
        public MensajeJson ListarVentasDetallado(string fechainicio, string fechafin, string idsucursal, string comprobante)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@fechainicio", fechainicio);
            parameters.Add("@fechafin", fechafin);
            parameters.Add("@idsucursal", idsucursal);
            parameters.Add("@comprobante", comprobante);
            return _connection.MetodoDatatabletostringsql("Reporte.sp_listar_ventadetallado", parameters);
        }
    }
}
