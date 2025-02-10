using CLINICA_API.Areas.General.Helpers;
using CLINICA_API.Modelo;
using Dapper;

namespace CLINICA_API.Areas.Medico.Data
{
    public class EspecialidadData
    {
        private readonly ServiceConnection _connection;
        public EspecialidadData(ServiceConnection connection)
        {
            _connection = connection;
        }

        public MensajeJson ListarEspecialidad_Combo()
        {
            var parameters = new DynamicParameters();
            return _connection.MetodoDatatabletostringsql("Medico.sp_listar_especialidad_combo", parameters);
        }
    }
}
