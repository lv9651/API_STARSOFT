using CLINICA_API.Areas.General.Helpers;
using CLINICA_API.Modelo;
using Dapper;

namespace CLINICA_API.Areas.Cita.Data
{
    public class ProcedenciaData
    {
        private readonly ServiceConnection _connection;
        public ProcedenciaData(ServiceConnection connection)
        {
            _connection = connection;
        }

        public MensajeJson ListarProcedencia_Combo()
        {
            var parameters = new DynamicParameters();
            return _connection.MetodoDatatabletostringsql("Citas.sp_listar_procedencia_combo", parameters);
        }
    }
}
