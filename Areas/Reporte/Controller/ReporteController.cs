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
        [HttpGet("ListarProcedimiento")]
        public string ListarProcedimiento(string fechainicio = "", string fechafin = "", string idsucursal = "")
        {
            return _service.ListarProcedimiento(fechainicio, fechafin, idsucursal);
        }
        [HttpGet("ListarNumeroConsultas")]
        public string ListarNumeroConsultas(string fechainicio = "", string fechafin = "", string idmedico = "")
        {
            return _service.ListarNumeroConsultas(fechainicio, fechafin, idmedico);
        }
        [HttpGet("ListarVentasDetallado")]
        public string ListarVentasDetallado(string fechainicio = "", string fechafin = "", string idsucursal = "", string comprobante = "")
        {
            return _service.ListarVentasDetallado(fechainicio, fechafin, idsucursal, comprobante);
        }
        [HttpGet("ListarCuadreCajaContabilidad")]
        public string ListarCuadreCajaContabilidad(string idsucursal = "", string fechainicio = "", string fechafin = "")
        {
            return _service.ListarCuadreCajaContabilidad(idsucursal, fechainicio, fechafin);
        }
    }
}
