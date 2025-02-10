using CLINICA_API.Areas.General.Helpers;
using CLINICA_API.Modelo;
using Dapper;
using Newtonsoft.Json;

namespace CLINICA_API.Areas.Medico.Data
{
    public class MedicoData
    {
        private readonly ServiceConnection _connection;
        public MedicoData(ServiceConnection connection)
        {
            _connection = connection;
        }
        public MensajeJson ListarMedicosxFiltro(string filtro)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@filtro", filtro);
            return _connection.MetodoDatatabletostringsql("Medico.sp_listar_medicoxfiltro", parameters);
        }
        public MensajeJson ObtenerMedicoxIdMedico(string idmedico) {
            var parameters = new DynamicParameters();
            parameters.Add("@idmedico", idmedico);
            return _connection.MetodoDatatabletostringsql("Medico.sp_obtener_medicoxidmedico", parameters);
        }
        public MensajeJson GuardarEditarMedico(string jsonmedico)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@jsonmedico", jsonmedico);
            return _connection.MetodoRespuestasql("Medico.sp_guardareditar_medico", parameters, 50);
        }
        public MensajeJson ListarMedicosDisponibles_Combo(string fecha, string idespecialidad, string idmodalidad, string idsucursal)
        {
            fecha = fecha.Replace("-", "/");
            var parameters = new DynamicParameters();
            parameters.Add("@fecha", fecha);
            parameters.Add("@idespecialidad", idespecialidad);
            parameters.Add("@idmodalidad", idmodalidad);
            parameters.Add("@idsucursal", idsucursal);
            return _connection.MetodoDatatabletostringsql("Medico.sp_listar_medicosdisponibles_combo", parameters);
        }
        public MensajeJson ListarMedicosxFiltro_Modal(string filtro)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@filtro", filtro);
            return _connection.MetodoDatatabletostringsql("Medico.sp_listar_medicoxfiltro_modal", parameters);
        }
        public MensajeJson ObtenerMedicoxNumColegiatura(string numcolegiatura)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@numcolegiatura", numcolegiatura);
            return _connection.MetodoDatatabletostringsql("Medico.sp_obtener_medicoxnumcolegiatura", parameters);
        }
    }
}
