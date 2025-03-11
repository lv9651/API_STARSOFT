using CLINICA_API.Areas.General.Helpers;
using CLINICA_API.Modelo;
using Dapper;

namespace CLINICA_API.Areas.Cita.Data
{
    public class DiagnosticoData
    {
        private readonly ServiceConnection _connection;
        public DiagnosticoData(ServiceConnection connection)
        {
            _connection = connection;
        }

        public MensajeJson ListarDiagnostico_Combo ()
        {
            var parameters = new DynamicParameters();
            return _connection.MetodoDatatabletostringsql("Citas.sp_listar_diagnostico_combo", parameters);
        }
        public MensajeJson ListarDiagnosticoxFiltro(string filtro)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@filtro", filtro);
            return _connection.MetodoDatatabletostringsql("Citas.sp_listar_diagnosticoxfiltro", parameters);
        }
        public MensajeJson ObtenerDiagnosticoxIdDiagnostico(string iddiagnostico)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@iddiagnostico", iddiagnostico);
            return _connection.MetodoDatatabletostringsql("Citas.sp_obtener_diagnosticoxiddiagnostico", parameters);
        }
        public MensajeJson GuardarEditarDiagnostico(string jsondiagnostico)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@jsondiagnostico", jsondiagnostico);
            return _connection.MetodoRespuestasql("Citas.sp_guardareditar_diagnostico", parameters, 50);
        }
    }
}
