using CLINICA_API.Areas.General.Helpers;
using CLINICA_API.Modelo;
using Dapper;

namespace CLINICA_API.Areas.Medico.Data
{
    public class ColegioData
    {
        private readonly ServiceConnection _connection;
        public ColegioData(ServiceConnection connection)
        {
            _connection = connection;
        }

        public MensajeJson ListarColegio_Combo()
        {
            var parameters = new DynamicParameters();
            return _connection.MetodoDatatabletostringsql("Medico.sp_listar_colegio_combo", parameters);
        }
    }
}
