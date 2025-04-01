using CLINICA_API.Areas.General.Helpers;
using CLINICA_API.Modelo;
using Dapper;

namespace CLINICA_API.Areas.Venta.Data
{
    public class CuadreCajaData
    {
        private readonly ServiceConnection _connection;
        public CuadreCajaData(ServiceConnection connection)
        {
            _connection = connection;
        }

        public MensajeJson ListarVentasCuadreCaja(string idusuario, string fechainicio, string fechafin)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@idusuario", idusuario);
            parameters.Add("@fechainicio", fechainicio);
            parameters.Add("@fechafin", fechafin);
            return _connection.MetodoDatatabletostringsql("Ventas.sp_listar_ventascuadres_cuadrecaja", parameters);
        }
        public MensajeJson ValidarGuardarCuadreCaja(string jsoncuadrecaja)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@jsoncuadrecaja", jsoncuadrecaja);
            return _connection.MetodoRespuestasql("Ventas.sp_validarguardar_primeraparte_cuadrecaja", parameters, 50);
        }
        public MensajeJson ObtenerCuadreCaja(string idcuadrecaja, string idusuario, string fecha)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@idcuadrecaja", idcuadrecaja);
            parameters.Add("@idusuario", idusuario);
            parameters.Add("@fecha", fecha);
            return _connection.MetodoDatatabletostringsql("Ventas.sp_obtener_cuadrecaja", parameters);
        }
        public MensajeJson EditarSegundaParteCuadreCaja(string jsoncuadrecaja)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@jsoncuadrecaja", jsoncuadrecaja);
            return _connection.MetodoRespuestasql("Ventas.sp_editar_segundaparte_cuadrecaja", parameters, 50);
        }
        public MensajeJson EditarTerceraParteCuadreCaja(string jsoncuadrecaja)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@jsoncuadrecaja", jsoncuadrecaja);
            return _connection.MetodoRespuestasql("Ventas.sp_editar_terceraparte_cuadrecaja", parameters, 50);
        }
    }
}
