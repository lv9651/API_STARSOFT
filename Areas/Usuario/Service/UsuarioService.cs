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
    }
}
