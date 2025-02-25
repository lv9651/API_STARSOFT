using CLINICA_API.Areas.General.Service;
using Microsoft.AspNetCore.Mvc;

namespace CLINICA_API.Areas.General.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagenPublicitariaController : ControllerBase
    {
        private readonly ImagenPublicitariaService _service;
        public ImagenPublicitariaController(ImagenPublicitariaService service)
        {
            _service = service;
        }

        [HttpGet("ListarImagenPublicitariaXFiltro")]
        public async Task<string> ListarImagenPublicitariaXFiltro(string filtro = "")
        {
            return await _service.ListarImagenPublicitariaXFiltro(filtro);
        }
        [HttpGet("ObtenerImagenPublicitariaxIdImagenPublicitaria/{idimagenpublicitaria}")]
        public string ObtenerImagenPublicitariaxIdImagenPublicitaria(string idimagenpublicitaria)
        {
            return _service.ObtenerImagenPublicitariaxIdImagenPublicitaria(idimagenpublicitaria);
        }
        [HttpPost("GuardarEditarImagenPublicitaria")]
        public string GuardarEditarImagenPublicitaria([FromBody] string jsonimagenpublicitaria)
        {
            var rptaregistro = _service.GuardarEditarImagenPublicitaria(jsonimagenpublicitaria);
            return rptaregistro;
        }
    }
}
