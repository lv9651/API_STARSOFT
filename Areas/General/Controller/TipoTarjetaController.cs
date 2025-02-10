using CLINICA_API.Areas.General.Service;
using Microsoft.AspNetCore.Mvc;

namespace CLINICA_API.Areas.General.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoTarjetaController : ControllerBase
    {
        private readonly TipoTarjetaService _service;
        public TipoTarjetaController(TipoTarjetaService service)
        {
            _service = service;
        }

        [HttpGet("ListarTipoTarjeta_Combo")]
        public string ListarTipoTarjeta_Combo()
        {
            return _service.ListarTipoTarjeta_Combo();
        }
    }
}
