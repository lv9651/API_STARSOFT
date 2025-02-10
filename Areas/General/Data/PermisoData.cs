using CLINICA_API.Areas.General.Helpers;
using CLINICA_API.Modelo;
using Dapper;

namespace CLINICA_API.Areas.General.Data
{
    public class PermisoData
    {
        private readonly ServiceConnection _connection;
        public PermisoData(ServiceConnection connection)
        {
            _connection = connection;
        }
        public MensajeJson ListarPermisosxIdUsuario(string idusuario)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@idusuario", idusuario);
            return _connection.MetodoDatatabletostringsql("General.sp_listar_permisosxidusuario", parameters);
        }
        public MensajeJson ListarPermisosxIdRol(string idrol)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@idrol", idrol);
            return _connection.MetodoDatatabletostringsql("General.sp_listar_permisosxidrol", parameters);
        }
    }
}
