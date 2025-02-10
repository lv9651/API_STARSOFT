using CLINICA_API.Areas.General.Helpers;
using CLINICA_API.Modelo;
using Dapper;

namespace CLINICA_API.Areas.General.Data
{
    public class EmpresaData
    {
        private readonly ServiceConnection _connection;
        public EmpresaData(ServiceConnection connection)
        {
            _connection = connection;
        }

        public MensajeJson ListarEmpresa_Combo()
        {
            var parameters = new DynamicParameters();
            return _connection.MetodoDatatabletostringsql("General.sp_listar_empresa_combo", parameters);
        }
    }
}
