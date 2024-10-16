using CLINICA_API.Areas.General.Helpers;
using Dapper;

namespace CLINICA_API.Areas.Usuario.Data
{
    public class UsuarioData
    {
        private readonly ServiceConnection _connection;
        public UsuarioData(ServiceConnection connection)
        {
            _connection = connection;
        }
        public string GetValLogin(string username,string clave)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@username", username);
            parameters.Add("@clave", clave);

            return _connection.MetodoDatatabletostringsql("general.login", parameters);
        }
        public string GetListaUsuario(string filtro)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@filtro", filtro);
            return _connection.MetodoDatatabletostringsql("general.lista_usuarios", parameters);
        }
        public string GetUsuarioxid(string idusuario) { 
            var parameters = new DynamicParameters();
            parameters.Add("@idusuario", idusuario);
            return _connection.MetodoDatatabletostringsql("general.buscarusuarioxid", parameters);
        }
        public string GuardarEditar(string jsonuser) {
            var parameters = new DynamicParameters();
            parameters.Add("@jsonuser", jsonuser);
            return _connection.MetodoRespuestasql("general.GuardarEditarUsuario", parameters,50);
        }
        public string GetPermisosxUsuarioxRol(string idusuario,string idrol) {
            var parameters = new DynamicParameters();
            parameters.Add("@idusuario", idusuario);
            parameters.Add("@idrol", idrol);
            return _connection.MetodoDatatabletostringsql("general.permisosxrolxusuario", parameters);
        }
        public string ActualizarPermisoxUsuario(string idusuario, string idpermiso) { 
            var parameters= new DynamicParameters();
            parameters.Add("@idusuario", idusuario);
            parameters.Add("@idpermiso", idpermiso);
            return _connection.MetodoRespuestasql("general.modificar_permiso", parameters);
        }
    }
}
