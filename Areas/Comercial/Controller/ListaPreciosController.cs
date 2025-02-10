using CLINICA_API.Areas.Comercial.Service;
using Microsoft.AspNetCore.Mvc;

namespace CLINICA_API.Areas.Comercial.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListaPreciosController : ControllerBase
    {
        private readonly ListaPreciosService _service;
        public ListaPreciosController(ListaPreciosService service)
        {
            _service = service;
        }

        [HttpGet("ListarListaPrecioxFiltro")]
        public string ListarListaPrecioxFiltro(string filtro = "")
        {
            return _service.ListarListaPrecioxFiltro(filtro);
        }
        [HttpGet("ObtenerListaPrecioxIdListaPrecio/{idlistaprecio}")]
        public string ObtenerListaPrecioxIdListaPrecio(string idlistaprecio)
        {
            return _service.ObtenerListaPrecioxIdListaPrecio(idlistaprecio);
        }
        [HttpPost("GuardarEditarListaPrecio")]
        public string GuardarEditarListaPrecio([FromBody] string jsonlistaprecios)
        {
            var rptaregistro = _service.GuardarEditarListaPrecio(jsonlistaprecios);
            return rptaregistro;
        }
        [HttpGet("ListarListaPrecioXIdSucursal_Combo/{idsucursal}")]
        public string ListarListaPrecioXIdSucursal_Combo(string idsucursal)
        {
            return _service.ListarListaPrecioXIdSucursal_Combo(idsucursal);
        }
    }
}
