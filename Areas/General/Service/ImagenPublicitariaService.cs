using CLINICA_API.Areas.General.Data;
using Newtonsoft.Json;

namespace CLINICA_API.Areas.General.Service
{
    public class ImagenPublicitariaService
    {
        private readonly ImagenPublicitariaData _data;
        public ImagenPublicitariaService(ImagenPublicitariaData data)
        {
            _data = data;
        }

        public async Task<string> ListarImagenPublicitariaXFiltro(string filtro)
        {
            return JsonConvert.SerializeObject(await _data.ListarImagenPublicitariaXFiltro(filtro));
        }
        public string ObtenerImagenPublicitariaxIdImagenPublicitaria(string idimagenpublicitaria)
        {
            return JsonConvert.SerializeObject(_data.ObtenerImagenPublicitariaxIdImagenPublicitaria(idimagenpublicitaria));
        }
        public string GuardarEditarImagenPublicitaria(string jsonimagenpublicitaria)
        {
            return JsonConvert.SerializeObject(_data.GuardarEditarImagenPublicitaria(jsonimagenpublicitaria));
        }
    }
}
