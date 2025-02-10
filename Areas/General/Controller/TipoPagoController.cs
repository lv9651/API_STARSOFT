using CLINICA_API.Areas.General.Service;
using Microsoft.AspNetCore.Mvc;

namespace CLINICA_API.Areas.General.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoPagoController : ControllerBase
    {
        private readonly TipoPagoService _service;
        public TipoPagoController(TipoPagoService service)
        {
            _service = service;
        }

        [HttpGet("ListarTipoPago_Combo")]
        public string ListarTipoPago_Combo()
        {
            return _service.ListarTipoPago_Combo();
        }
    }
}
