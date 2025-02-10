using CLINICA_API.Areas.General.Helpers;
using CLINICA_API.Modelo;
using Dapper;

namespace CLINICA_API.Areas.Cita.Data
{
    public class TipoSangreData
    {
        private readonly ServiceConnection _connection;
        public TipoSangreData(ServiceConnection connection)
        {
            _connection = connection;
        }

        public MensajeJson ListarTipoSangre_Combo()
        {
            var parameters = new DynamicParameters();
            return _connection.MetodoDatatabletostringsql("Citas.sp_listar_tiposangre_combo", parameters);
        }
    }
}
