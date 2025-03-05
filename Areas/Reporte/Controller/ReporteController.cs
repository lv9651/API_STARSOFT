using CLINICA_API.Areas.Reporte.Service;
using Microsoft.AspNetCore.Mvc;

namespace CLINICA_API.Areas.Reporte.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReporteController : ControllerBase
    {
        private readonly ReporteService _service;
        public ReporteController(ReporteService service)
        {
            _service = service;
        }

        [HttpGet("ListarCuadreCaja")]
        public string ListarCuadreCaja(string idusuario = "", string idsucursal = "", string fecha = "")
        {
            return _service.ListarCuadreCaja(idusuario, idsucursal, fecha);
        }
    }
}
