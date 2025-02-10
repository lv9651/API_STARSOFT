using CLINICA_API.Areas.General.Service;
using Microsoft.AspNetCore.Mvc;

namespace CLINICA_API.Areas.General.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConstanteController : ControllerBase
    {
        private readonly ConstanteService _service;
        public ConstanteController(ConstanteService service)
        {
            _service = service;
        }
        [HttpGet("ListasGenerales")]
        public async Task<string> ListasGenerales()
        {
            return await _service.ListasGenerales();
        }
    }
}
