using CLINICA_API.Areas.General.Service;
using CLINICA_API.Areas.Medico.Service;
using Microsoft.AspNetCore.Mvc;

namespace CLINICA_API.Areas.General.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class SucursalController : ControllerBase
    {
        private readonly SucursalService _service;
        public SucursalController(SucursalService service)
        {
            _service = service;
        }

        [HttpGet("ListarSucursalxIdEmpresa_Combo/{idempresa}")]
        public string ListarSucursalxIdEmpresa_Combo(string idempresa)
        {
            return _service.ListarSucursalxIdEmpresa_Combo(idempresa);
        }
        [HttpGet("ListarSucuralxFiltro")]
        public string ListarSucuralxFiltro(string filtro = "")
        {
            return _service.ListarSucuralxFiltro(filtro);
        }
        [HttpGet("ObtenerSucursalxIdSucursal/{idsucursal}")]
        public string ObtenerSucursalxIdSucursal(string idsucursal)
        {
            return _service.ObtenerSucursalxIdSucursal(idsucursal);
        }
        [HttpPost("GuardarEditarSucursal")]
        public string GuardarEditarSucursal([FromBody] string jsonsucursal)
        {
            var rptaregistro = _service.GuardarEditarSucursal(jsonsucursal);
            return rptaregistro;
        }
        [HttpPost("GuardarEditarListaPrecioSucursal")]
        public string GuardarEditarListaPrecioSucursal([FromBody] string jsonlistapreciosucursal)
        {
            var rptaregistro = _service.GuardarEditarListaPrecioSucursal(jsonlistapreciosucursal);
            return rptaregistro;
        }
        [HttpPost("GuardarEditarCorrelativoSucursal")]
        public string GuardarEditarCorrelativoSucursal([FromBody] string jsoncorrelativosucursal)
        {
            var rptaregistro = _service.GuardarEditarCorrelativoSucursal(jsoncorrelativosucursal);
            return rptaregistro;
        }
        [HttpGet("ListarCorrelativoxIdSucursal/{idsucursal}")]
        public string ListarCorrelativoxIdSucursal(string idsucursal)
        {
            return _service.ListarCorrelativoxIdSucursal(idsucursal);
        }
    }
}
