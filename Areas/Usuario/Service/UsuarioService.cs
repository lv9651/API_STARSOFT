using CLINICA_API.Areas.Medico.Data;
using CLINICA_API.Areas.Usuario.Data;
using CLINICA_API.Modelo;
using Newtonsoft.Json;

namespace CLINICA_API.Areas.Usuario.Service
{
    public class UsuarioService
    {
        private readonly UsuarioData _data;
        public UsuarioService(UsuarioData data)
        {
            _data = data;
        }
        public string ValidarCredenciales(string jsoncredenciales)
        {
            return JsonConvert.SerializeObject(_data.ValidarCredenciales(jsoncredenciales));
        }
        public string ListarUsuarios(string filtro) {
            return JsonConvert.SerializeObject(_data.ListarUsuarios(filtro));
        }
        public string ObtenerUsuarioxIdUsuario(string idusuario) {
            return JsonConvert.SerializeObject(_data.ObtenerUsuarioxIdUsuario(idusuario));
        }
        public string GuardarEditarUsuario(string jsonuser) {
            return JsonConvert.SerializeObject(_data.GuardarEditarUsuario(jsonuser));
        }
        public string ListarRolParaUsuario()
        {
            return JsonConvert.SerializeObject(_data.ListarRolParaUsuario());
        }
        public string ListarUsuariosxFiltro_Modal(string filtro)
        {
            return JsonConvert.SerializeObject(_data.ListarUsuariosxFiltro_Modal(filtro));
        }
    }
}
