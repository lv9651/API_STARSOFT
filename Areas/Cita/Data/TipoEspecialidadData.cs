using CLINICA_API.Areas.General.Helpers;
using CLINICA_API.Modelo;
using Dapper;

namespace CLINICA_API.Areas.Cita.Data
{
    public class TipoEspecialidadData
    {
        private readonly ServiceConnection _connection;
        public TipoEspecialidadData(ServiceConnection connection)
        {
            _connection = connection;
        }

        public MensajeJson ListarTipoEspecialidad_Combo()
        {
            var parameters = new DynamicParameters();
            return _connection.MetodoDatatabletostringsql("Citas.sp_listar_tipoespecialidad_combo", parameters);
        }
    }
}
