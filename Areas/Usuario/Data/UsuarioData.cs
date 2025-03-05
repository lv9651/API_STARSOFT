using CLINICA_API.Areas.General.Helpers;
using CLINICA_API.Modelo;
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
        public MensajeJson ValidarCredenciales(string jsoncredenciales)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@jsoncredenciales", jsoncredenciales);
            return _connection.MetodoDatatabletostringsql("General.sp_validar_usuariocredenciales", parameters);
        }
        public MensajeJson ListarUsuarios(string filtro)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@filtro", filtro);
            return _connection.MetodoDatatabletostringsql("General.sp_listar_usuariosxfiltro", parameters);
        }
        public MensajeJson ObtenerUsuarioxIdUsuario(string idusuario) { 
            var parameters = new DynamicParameters();
            parameters.Add("@idusuario", idusuario);
            return _connection.MetodoDatatabletostringsql("General.sp_obtener_usuarioxidusuario", parameters);
        }
        public MensajeJson GuardarEditarUsuario(string jsonuser) {
            var parameters = new DynamicParameters();
            parameters.Add("@jsonusuario", jsonuser);
            return _connection.MetodoRespuestasql("General.sp_guardareditar_usuario", parameters, 50);
        }
        public MensajeJson ListarRolParaUsuario()
        {
            var parameters = new DynamicParameters();
            return _connection.MetodoDatatabletostringsql("General.sp_listar_rolparausuario", parameters);
        }
        public MensajeJson ListarUsuariosxFiltro_Modal(string filtro)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@filtro", filtro);
            return _connection.MetodoDatatabletostringsql("General.sp_listar_usuariosxfiltro_modal", parameters);
        }
    }
}
