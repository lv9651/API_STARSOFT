using CLINICA_API.Areas.General.Helpers;
using CLINICA_API.Modelo;
using Dapper;

namespace CLINICA_API.Areas.Procedimiento.Data
{
    public class ProcedimientoData
    {
        private readonly ServiceConnection _connection;
        public ProcedimientoData(ServiceConnection connection)
        {
            _connection = connection;
        }
        public MensajeJson ListarProcedimientoxFiltro(string fechainicio, string fechafin, string idsucursal)
        {
            fechainicio = fechainicio.Replace("-", "/");
            fechafin = fechafin.Replace("-", "/");
            var parameters = new DynamicParameters();
            parameters.Add("@fechainicio", fechainicio);
            parameters.Add("@fechafin", fechafin);
            parameters.Add("@idsucursal", idsucursal);
            return _connection.MetodoDatatabletostringsql("Procedimientos.sp_listar_procedimientoxfiltro", parameters);
        }
        public MensajeJson GuardarEditarProcedimiento(string jsonprocedimiento)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@jsonprocedimiento", jsonprocedimiento);
            return _connection.MetodoRespuestasql("Procedimientos.sp_guardareditar_procedimiento", parameters, 50);
        }
        public MensajeJson EliminarProcedimiento(string idprocedimiento)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@idprocedimiento", idprocedimiento);
            return _connection.MetodoRespuestasql("Procedimientos.sp_eliminar_procedimiento", parameters, 50);
        }
        public MensajeJson ObtenerProcedimientoxIdPaciente_ModalProcedimientoPaciente(string idprocedimiento)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@idprocedimiento", idprocedimiento);
            return _connection.MetodoDatatabletostringsql("Procedimientos.sp_obtener_procedimientoxidprocedimiento_modalprocedimientopaciente", parameters);
        }
        public MensajeJson ListarTurno_Combo()
        {
            var parameters = new DynamicParameters();
            return _connection.MetodoDatatabletostringsql("Procedimientos.sp_listar_turno_combo", parameters);
        }
    }
}
