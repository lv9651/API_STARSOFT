using CLINICA_API.Areas.General.Helpers;
using CLINICA_API.Modelo;
using Dapper;

namespace CLINICA_API.Areas.General.Data
{
    public class DocumentoTributarioData
    {
        private readonly ServiceConnection _connection;
        public DocumentoTributarioData(ServiceConnection connection)
        {
            _connection = connection;
        }

        public MensajeJson ListarDocumentoTributario_Combo()
        {
            var parameters = new DynamicParameters();
            return _connection.MetodoDatatabletostringsql("General.sp_listar_documentotributario_combo", parameters);
        }
        public MensajeJson ListarDocumentoTributarioxIdSucursalxCobro_Combo(string idsucursal)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@idsucursal", idsucursal);
            return _connection.MetodoDatatabletostringsql("General.sp_listar_documentotributarioxidsucursalxcobro_combo", parameters);
        }
        public async Task<MensajeJson> ListarDocumentoTributarioXFiltro(string filtro)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@filtro", filtro);
            return await _connection.MetodoDatatabletostringsqlasync("General.sp_listar_documentotributarioxfiltro", parameters);
        }
        public MensajeJson ObtenerDocumentoTributarioxIdDocumentoTributario(string iddocumentotributario)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@iddocumentotributario", iddocumentotributario);
            return _connection.MetodoDatatabletostringsql("General.sp_obtener_documentotributarioxiddocumentotributario", parameters);
        }
        public MensajeJson GuardarEditarDocumentoTributario(string jsondocumentotributario)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@jsondocumentotributario", jsondocumentotributario);
            return _connection.MetodoRespuestasql("General.sp_guardareditar_documentotributario", parameters, 50);
        }
        public MensajeJson ListarMotivoEmisionDocumentoTributarioxIdDocumentoTributario(string iddocumentotributario)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@iddocumentotributario", iddocumentotributario);
            return _connection.MetodoDatatabletostringsql("General.sp_listar_motivoemisiondocumentotributarioxiddocumentotributario", parameters);
        }
        public MensajeJson GuardarEditarMotivoEmisionDocumentoTributario(string jsonmotivoemisiondocumentotributario)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@jsonmotivoemisiondocumentotributario", jsonmotivoemisiondocumentotributario);
            return _connection.MetodoRespuestasql("General.sp_guardareditar_motivoemisiondocumentotributario", parameters, 50);
        }
    }
}
