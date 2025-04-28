using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class OrdenCompraController : ControllerBase
{
    private readonly InvoiceService _service;

    public OrdenCompraController(InvoiceService service)
    {
        _service = service;
    }

    [HttpGet("por-invoice/{invoice}")]
    public async Task<ActionResult<OrdenCompra>> GetPorInvoice(string invoice)
    {
        try
        {
            var resultado = await _service.ObtenerOrdenCompraPorInvoiceAsync(invoice);

            if (resultado.MensajeError != null)
            {
                return NotFound(new { resultado.MensajeError });
            }

            return Ok(resultado);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Mensaje = $"Error interno: {ex.Message}" });
        }
    }
}