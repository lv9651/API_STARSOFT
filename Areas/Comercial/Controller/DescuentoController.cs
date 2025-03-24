using CLINICA_API.Areas.Comercial.Service;
using Microsoft.AspNetCore.Mvc;

namespace CLINICA_API.Areas.Comercial.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class DescuentoController : ControllerBase
    {
        private readonly DescuentoService _service;
        public DescuentoController(DescuentoService service)
        {
            _service = service;
        }

        [HttpGet("ListarDescuentoxFiltro")]
        public string ListarDescuentoxFiltro(string fechainicio = "", string fechafin = "", string filtro = "")
        {
            return _service.ListarDescuentoxFiltro(fechainicio, fechafin, filtro);
        }
        [HttpGet("ListarSucursalxFiltro_Modal")]
        public string ListarSucursalxFiltro_Modal(string filtro = "")
        {
            return _service.ListarSucursalxFiltro_Modal(filtro);
        }
        [HttpGet("ListarListaPrecioxFiltro_Modal")]
        public string ListarListaPrecioxFiltro_Modal(string filtro = "")
        {
            return _service.ListarListaPrecioxFiltro_Modal(filtro);
        }
        [HttpGet("ListarTipoProductoxFiltro_Modal")]
        public string ListarTipoProductoxFiltro_Modal(string filtro = "")
        {
            return _service.ListarTipoProductoxFiltro_Modal(filtro);
        }
        [HttpGet("ListarProductoxFiltro_Modal")]
        public string ListarProductoxFiltro_Modal(string filtro = "")
        {
            return _service.ListarProductoxFiltro_Modal(filtro);
        }
        [HttpGet("ListarClientexFiltro_Modal")]
        public string ListarClientexFiltro_Modal(string filtro = "")
        {
            return _service.ListarClientexFiltro_Modal(filtro);
        }
        [HttpGet("ListarTipoDescuento_Combo")]
        public string ListarTipoDescuento_Combo()
        {
            return _service.ListarTipoDescuento_Combo();
        }
        [HttpPost("GuardarEditarDescuento")]
        public string GuardarEditarDescuento([FromBody] string jsondescuento)
        {
            var rptaregistro = _service.GuardarEditarDescuento(jsondescuento);
            return rptaregistro;
        }
        [HttpGet("ObtenerDescuentoxIdDescuento/{iddescuento}")]
        public string ObtenerDescuentoxIdDescuento(string iddescuento)
        {
            return _service.ObtenerDescuentoxIdDescuento(iddescuento);
        }
        [HttpGet("EliminarDescuento/{iddescuento}")]
        public string EliminarDescuento(string iddescuento)
        {
            return _service.EliminarDescuento(iddescuento);
        }
        [HttpGet("ObtenerDescuentoParaVenta/{idsucursal}/{idlistaprecio}")]
        public string ObtenerDescuentoParaVenta(string idsucursal, string idlistaprecio)
        {
            return _service.ObtenerDescuentoParaVenta(idsucursal, idlistaprecio);
        }
    }
}
