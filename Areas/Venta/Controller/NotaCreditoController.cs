using CLINICA_API.Areas.Venta.Service;
using Microsoft.AspNetCore.Mvc;

namespace CLINICA_API.Areas.Venta.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotaCreditoController : ControllerBase
    {
        private readonly NotaCreditoService _service;
        public NotaCreditoController(NotaCreditoService service)
        {
            _service = service;
        }

        [HttpGet("ListarNotaCreditoXFiltro")]
        public async Task<string> ListarNotaCreditoXFiltro(string fechainicio = "", string fechafin = "", string filtro = "")
        {
            return await _service.ListarNotaCreditoXFiltro(fechainicio, fechafin, filtro);
        }
        [HttpGet("ObtenerNotaCreditoxIdNotaCredito/{idnota}")]
        public string ObtenerNotaCreditoxIdNotaCredito(string idnota)
        {
            return _service.ObtenerNotaCreditoxIdNotaCredito(idnota);
        }
        [HttpPost("GuardarEditarNotaCredito")]
        public string GuardarEditarNotaCredito([FromBody] string jsonnotacredito)
        {
            var rptaregistro = _service.GuardarEditarNotaCredito(jsonnotacredito);
            return rptaregistro;
        }
        [HttpGet("ObtenerDatosComprobantexIdNotaCredito/{idnota}")]
        public string ObtenerDatosComprobantexIdNotaCredito(string idnota)
        {
            return _service.ObtenerDatosComprobantexIdNotaCredito(idnota);
        }


    }
}
