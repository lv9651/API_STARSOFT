using CLINICA_API.Areas.General.Service;
using CLINICA_API.Areas.Procedimiento.Service;
using Microsoft.AspNetCore.Mvc;

namespace CLINICA_API.Areas.Procedimiento.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcedimientoController : ControllerBase
    {
        private readonly ProcedimientoService _service;
        public ProcedimientoController(ProcedimientoService service)
        {
            _service = service;
        }
        [HttpGet("ListarProcedimientoxFiltro/{fechainicio}/{fechafin}/{idsucursal}")]
        public string ListarProcedimientoxFiltro(string fechainicio, string fechafin, string idsucursal)
        {
            return _service.ListarProcedimientoxFiltro(fechainicio, fechafin, idsucursal);
        }
        [HttpPost("GuardarEditarProcedimiento")]
        public string GuardarEditarProcedimiento([FromBody] string jsonprocedimiento)
        {
            var rptaregistro = _service.GuardarEditarProcedimiento(jsonprocedimiento);
            return rptaregistro;
        }
        [HttpGet("EliminarProcedimiento/{idprocedimiento}")]
        public string EliminarProcedimiento(string idprocedimiento)
        {
            return _service.EliminarProcedimiento(idprocedimiento);
        }
        [HttpGet("ObtenerProcedimientoxIdPaciente_ModalProcedimientoPaciente/{idpaciente}")]
        public string ObtenerProcedimientoxIdPaciente_ModalProcedimientoPaciente(string idpaciente)
        {
            return _service.ObtenerProcedimientoxIdPaciente_ModalProcedimientoPaciente(idpaciente);
        }
    }
}
