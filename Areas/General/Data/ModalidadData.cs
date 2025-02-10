using CLINICA_API.Areas.General.Helpers;
using CLINICA_API.Modelo;
using Dapper;

namespace CLINICA_API.Areas.General.Data
{
    public class ModalidadData
    {
        private readonly ServiceConnection _connection;
        public ModalidadData(ServiceConnection connection)
        {
            _connection = connection;
        }
        public MensajeJson ListarModalidad_Combo()
        {
            var parameters = new DynamicParameters();
            return _connection.MetodoDatatabletostringsql("General.sp_listar_modalidad_combo", parameters);
        }
    }
}
