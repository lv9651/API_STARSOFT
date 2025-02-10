using CLINICA_API.Areas.General.Helpers;
using CLINICA_API.Modelo;
using Dapper;

namespace CLINICA_API.Areas.General.Data
{
    public class RolData
    {
        private readonly ServiceConnection _connection;
        public RolData(ServiceConnection connection)
        {
            _connection = connection;
        }
        public async Task<MensajeJson> ListarRoles(string filtro)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@filtro", filtro);
            return await _connection.MetodoDatatabletostringsqlasync("General.sp_listar_rolesxfiltro", parameters);
        }
        public MensajeJson ObtenerRolxIdRol(string idrol)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@idrol", idrol);
            return _connection.MetodoDatatabletostringsql("General.sp_obtener_rolxidrol", parameters);
        }
        public MensajeJson GuardarEditarRol(string jsonrol)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@jsonrol", jsonrol);
            return _connection.MetodoRespuestasql("General.sp_guardareditar_rol", parameters, 50);
        }
    }
}
