using CLINICA_API.Areas.General.Helpers;
using CLINICA_API.Modelo;
using Dapper;

namespace CLINICA_API.Areas.General.Data
{
    public class RolPermisoData
    {
        private readonly ServiceConnection _connection;
        public RolPermisoData(ServiceConnection connection)
        {
            _connection = connection;
        }

        public MensajeJson GuardarEditarRolPermiso(string jsonrolpermiso)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@jsonrolpermiso", jsonrolpermiso);
            return _connection.MetodoRespuestasql("General.sp_registrareditar_rolpermisoxjson", parameters, 50);
        }
    }
}
