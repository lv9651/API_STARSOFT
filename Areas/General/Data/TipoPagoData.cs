using CLINICA_API.Areas.General.Helpers;
using CLINICA_API.Modelo;
using Dapper;

namespace CLINICA_API.Areas.General.Data
{
    public class TipoPagoData
    {
        private readonly ServiceConnection _connection;
        public TipoPagoData(ServiceConnection connection)
        {
            _connection = connection;
        }
        public MensajeJson ListarTipoPago_Combo()
        {
            var parameters = new DynamicParameters();
            return _connection.MetodoDatatabletostringsql("General.sp_listar_tipopago_combo", parameters);
        }
    }
}
