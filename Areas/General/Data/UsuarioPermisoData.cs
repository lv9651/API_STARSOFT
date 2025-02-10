using CLINICA_API.Areas.General.Helpers;
using CLINICA_API.Modelo;
using Dapper;

namespace CLINICA_API.Areas.General.Data
{
    public class UsuarioPermisoData
    {
        private readonly ServiceConnection _connection;
        public UsuarioPermisoData(ServiceConnection connection)
        {
            _connection = connection;
        }
        public MensajeJson GuardarEditarUsuarioPermiso(string jsonusuariopermiso)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@jsonusuariopermiso", jsonusuariopermiso);
            return _connection.MetodoRespuestasql("General.sp_registrareditar_usuariopermisoxjson", parameters, 50);
        }
        
    }
}
