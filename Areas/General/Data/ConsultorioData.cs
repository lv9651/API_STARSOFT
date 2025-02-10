using CLINICA_API.Areas.General.Helpers;
using CLINICA_API.Modelo;
using Dapper;

namespace CLINICA_API.Areas.General.Data
{
    public class ConsultorioData
    {
        private readonly ServiceConnection _connection;
        public ConsultorioData(ServiceConnection connection)
        {
            _connection = connection;
        }
        public MensajeJson ListarConsultorio_Combo()
        {
            var parameters = new DynamicParameters();
            return _connection.MetodoDatatabletostringsql("General.sp_listar_consultorio_combo", parameters);
        }
    }
}
