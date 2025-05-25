using Microsoft.AspNetCore.Mvc;
using STARSOFT_API.Areas.ORDER_COMPRA.Modelo;
using System;
using System.Threading.Tasks;
using TuProyecto.Repositories;
using TuProyecto.Services;

namespace TuProyecto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImportacionController : ControllerBase
    {
        private readonly ImportacionService _service;

        public ImportacionController(ImportacionService service)
        {
            _service = service;
        }


        [HttpGet("{ordenCompra}")]
        public async Task<IActionResult> ObtenerDatos(string ordenCompra)
        {
            var datos = await _service.ObtenerPorOrdenCompraAsync(ordenCompra);

            if ((datos.TablaInvoice?.Count ?? 0) == 0 &&
                (datos.TablaCaltimereal?.Count ?? 0) == 0 &&
                (datos.TablaDua?.Count ?? 0) == 0 &&
                (datos.DistribucionFinal?.Count ?? 0) == 0)
            {
                return NotFound(new { mensaje = "No se encontraron datos para la orden de compra especificada." });
            }

            return Ok(datos);
        }

        [HttpPost("registrar")]
        public async Task<IActionResult> RegistrarImportacion([FromBody] ImportacionRequest request)
        {
            if (request == null ||
                string.IsNullOrWhiteSpace(request.JsonInvoice) ||
                string.IsNullOrWhiteSpace(request.JsonCaltimereal) ||
                string.IsNullOrWhiteSpace(request.JsonDua) ||
                string.IsNullOrWhiteSpace(request.JsonDistribucionFinal))
            {
                return BadRequest("Todos los campos JSON son requeridos.");
            }

            try
            {
                await _service.RegistrarImportacionAsync(request);
                return Ok(new { mensaje = "Importación registrada correctamente." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = $"Error al registrar: {ex.Message}" });
            }
        }
    }
}