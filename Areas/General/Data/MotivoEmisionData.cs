using CLINICA_API.Areas.General.Helpers;
using CLINICA_API.Modelo;
using Dapper;

namespace CLINICA_API.Areas.General.Data
{
    public class MotivoEmisionData
    {
        private readonly ServiceConnection _connection;
        public MotivoEmisionData(ServiceConnection connection)
        {
            _connection = connection;
        }

        public async Task<MensajeJson> ListarMotivoEmisionXFiltro(string filtro)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@filtro", filtro);
            return await _connection.MetodoDatatabletostringsqlasync("General.sp_listar_motivoemisionxfiltro", parameters);
        }
        public MensajeJson ObtenerMotivoEmisionxIdMotivoEmision(string idmotivoemision)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@idmotivoemision", idmotivoemision);
            return _connection.MetodoDatatabletostringsql("General.sp_obtener_motivoemisionxidmotivoemision", parameters);
        }
        public MensajeJson GuardarEditarDocumentoMotivoEmision(string jsonmotivoemision)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@jsonmotivoemision", jsonmotivoemision);
            return _connection.MetodoRespuestasql("General.sp_guardareditar_motivoemision", parameters, 50);
        }
    }
}
