using CLINICA_API.Areas.General.Helpers;
using CLINICA_API.Modelo;
using Dapper;
using static CLINICA_API.Areas.General.Helpers.ServiceConnection;

namespace CLINICA_API.Areas.General.Data
{
    public class ConstanteData
    {
        private readonly ServiceConnection _connection;
        public ConstanteData(ServiceConnection connection)
        {
            _connection = connection;
        }

        public async Task<MensajeJson> ListasGenerales()
        {
            return await _connection.MetodoDatatabletostringsqlasync("General.sp_listar_listasgenerales", null);
        }
    }
}
