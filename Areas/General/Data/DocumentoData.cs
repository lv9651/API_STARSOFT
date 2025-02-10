using CLINICA_API.Areas.General.Helpers;
using CLINICA_API.Modelo;
using Dapper;
using static CLINICA_API.Areas.General.Helpers.ServiceConnection;

namespace CLINICA_API.Areas.General.Data
{
    public class DocumentoData
    {
        private readonly ServiceConnection _connection;
        public DocumentoData(ServiceConnection connection)
        {
            _connection = connection;
        }

        public MensajeJson ListarDocumento_Combo()
        {
            var parameters = new DynamicParameters();
            return _connection.MetodoDatatabletostringsql("Clinica.sp_listar_documento_combo", parameters , TipoConexion.SIGE);
        }
    }
}
