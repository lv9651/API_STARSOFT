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
    }
}
