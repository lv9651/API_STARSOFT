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
    }
}
