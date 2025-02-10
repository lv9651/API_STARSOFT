using CLINICA_API.Areas.General.Helpers;
using CLINICA_API.Modelo;
using Dapper;

namespace CLINICA_API.Areas.General.Data
{
    public class EstadoData
    {
        private readonly ServiceConnection _connection;
        public EstadoData(ServiceConnection connection)
        {
            _connection = connection;
        }
        public MensajeJson ListarEstadoxIdGrupoEstado(string idgrupoestado)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@idgrupoestado", idgrupoestado);
            return _connection.MetodoDatatabletostringsql("General.sp_listar_estadoxidgrupoestado", parameters);
        }
    }
}
