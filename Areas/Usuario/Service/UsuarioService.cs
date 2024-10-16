using CLINICA_API.Areas.Medico.Data;
using CLINICA_API.Areas.Usuario.Data;

namespace CLINICA_API.Areas.Usuario.Service
{
    public class UsuarioService
    {
        private readonly UsuarioData _data;
        public UsuarioService(UsuarioData data)
        {
            _data = data;
        }
        public string GetValLogin(string username,string clave)
        {
            return _data.GetValLogin(username,clave);
        }
        public string GetListaUsuario(string filtro) {
            return _data.GetListaUsuario(filtro);
        }
        public string GetUsuarioxid(string idusuario) {
            return _data.GetUsuarioxid(idusuario);
        }
        public string GuardarEditar(string jsonuser) {
            return _data.GuardarEditar(jsonuser);
        }
        public string GetPermisosxUsuarioxRol(string idusuario, string idrol) { 
            return _data.GetPermisosxUsuarioxRol(idusuario, idrol);
        }
        public string ActualizarPermisoxUsuario(string idusuario, string idpermiso) {
            return _data.ActualizarPermisoxUsuario(idusuario, idpermiso);
        }
    }
}
