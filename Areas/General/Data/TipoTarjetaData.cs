using CLINICA_API.Areas.General.Helpers;
using CLINICA_API.Modelo;
using Dapper;

namespace CLINICA_API.Areas.General.Data
{
    public class TipoTarjetaData
    {
        private readonly ServiceConnection _connection;
        public TipoTarjetaData(ServiceConnection connection)
        {
            _connection = connection;
        }
        public MensajeJson ListarTipoTarjeta_Combo()
        {
            var parameters = new DynamicParameters();
            return _connection.MetodoDatatabletostringsql("General.sp_listar_tipotarjeta_combo", parameters);
        }
    }
}
