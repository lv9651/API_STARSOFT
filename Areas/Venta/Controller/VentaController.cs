using CLINICA_API.Areas.General.Service;
using CLINICA_API.Areas.Venta.Service;
using Microsoft.AspNetCore.Mvc;

namespace CLINICA_API.Areas.Venta.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private readonly VentaService _service;
        public VentaController(VentaService service)
        {
            _service = service;
        }

        [HttpGet("ObtenerDatosComprobantexIdVenta/{idventa}")]
        public string ObtenerDatosComprobantexIdVenta(string idventa)
        {
            return _service.ObtenerDatosComprobantexIdVenta(idventa);
        }
        [HttpGet("ObtenerDatosVentaParaCompletarPagoxIdVenta/{idventa}")]
        public string ObtenerDatosVentaParaCompletarPagoxIdVenta(string idventa)
        {
            return _service.ObtenerDatosVentaParaCompletarPagoxIdVenta(idventa);
        }
        [HttpPost("GuardarEditarComplementoVentaPago")]
        public string GuardarEditarComplementoVentaPago([FromBody] string jsonventapago)
        {
            var rptaregistro = _service.GuardarEditarComplementoVentaPago(jsonventapago);
            return rptaregistro;
        }
    }
}