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
        [HttpGet("ListarVentasNC_Modal")]
        public string ListarVentasNC_Modal(string fechainicio = "", string fechafin = "", string idsucursal = "", string comprobante = "")
        {
            return _service.ListarVentasNC_Modal(fechainicio, fechafin, idsucursal, comprobante);
        }
        [HttpGet("ObtenerDatosVentaParaNCxIdVenta/{idventa}")]
        public string ObtenerDatosVentaParaNCxIdVenta(string idventa)
        {
            return _service.ObtenerDatosVentaParaNCxIdVenta(idventa);
        }
        [HttpGet("EnviarJsonVentaNubefact/{idventa}")]
        public string EnviarJsonVentaNubefact(string idventa)
        {
            return _service.EnviarJsonVentaNubefact(idventa);
        }
        [HttpPost("EditarTxtGeneradoVenta")]
        public string EditarTxtGeneradoVenta([FromBody] string jsonidventa)
        {
            var rptaregistro = _service.EditarTxtGeneradoVenta(jsonidventa);
            return rptaregistro;
        }
    }
}