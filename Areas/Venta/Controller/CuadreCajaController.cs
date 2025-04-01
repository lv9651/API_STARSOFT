using CLINICA_API.Areas.Venta.Service;
using Microsoft.AspNetCore.Mvc;

namespace CLINICA_API.Areas.Venta.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuadreCajaController : ControllerBase
    {
        private readonly CuadreCajaService _service;
        public CuadreCajaController(CuadreCajaService service)
        {
            _service = service;
        }
        [HttpGet("ListarVentasCuadreCaja")]
        public string ListarVentasCuadreCaja(string idusuario = "", string fechainicio = "", string fechafin = "")
        {
            return _service.ListarVentasCuadreCaja(idusuario, fechainicio, fechafin);
        }
        [HttpPost("ValidarGuardarCuadreCaja")]
        public string ValidarGuardarCuadreCaja([FromBody] string jsoncuadrecaja)
        {
            var rptaregistro = _service.ValidarGuardarCuadreCaja(jsoncuadrecaja);
            return rptaregistro;
        }
        [HttpGet("ObtenerCuadreCaja")]
        public string ObtenerCuadreCaja(string idcuadrecaja = "", string idusuario = "", string fecha = "")
        {
            return _service.ObtenerCuadreCaja(idcuadrecaja, idusuario, fecha);
        }
        [HttpPost("EditarSegundaParteCuadreCaja")]
        public string EditarSegundaParteCuadreCaja([FromBody] string jsoncuadrecaja)
        {
            var rptaregistro = _service.EditarSegundaParteCuadreCaja(jsoncuadrecaja);
            return rptaregistro;
        }
        [HttpPost("EditarTerceraParteCuadreCaja")]
        public string EditarTerceraParteCuadreCaja([FromBody] string jsoncuadrecaja)
        {
            var rptaregistro = _service.EditarTerceraParteCuadreCaja(jsoncuadrecaja);
            return rptaregistro;
        }
    }
}
