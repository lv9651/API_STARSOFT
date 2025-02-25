using CLINICA_API.Areas.General.Helpers;
using CLINICA_API.Modelo;
using Dapper;
using System.Data.Common;

namespace CLINICA_API.Areas.General.Data
{
    public class ImagenPublicitariaData
    {
        private readonly ServiceConnection _connection;
        public ImagenPublicitariaData(ServiceConnection connection)
        {
            _connection = connection;
        }

        public async Task<MensajeJson> ListarImagenPublicitariaXFiltro(string filtro)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@filtro", filtro);
            return await _connection.MetodoDatatabletostringsqlasync("General.sp_listar_imagenpublicitarioxfiltro", parameters);
        }
        public MensajeJson ObtenerImagenPublicitariaxIdImagenPublicitaria(string idimagenpublicitaria)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@idimagenpublicitaria", idimagenpublicitaria);
            return _connection.MetodoDatatabletostringsql("General.sp_obtener_imagenpublicitariaxidimagenpublicitaria", parameters);
        }
        public MensajeJson GuardarEditarImagenPublicitaria(string jsonimagenpublicitaria)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@jsonimagenpublicitaria", jsonimagenpublicitaria);
            return _connection.MetodoRespuestasql("General.sp_guardareditar_imagenpublicitaria", parameters, 50);
        }
    }
}
