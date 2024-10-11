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
    }
}
