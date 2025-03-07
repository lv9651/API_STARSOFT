using CLINICA_API.Areas.Cita.Service;
using CLINICA_API.Areas.Medico.Service;
using Microsoft.AspNetCore.Mvc;

namespace CLINICA_API.Areas.Cita.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitaController : ControllerBase
    {
        private readonly CitaService _service;
        public CitaController(CitaService service)
        {
            _service = service;
        }

        [HttpGet("ListarCitaxFiltro")]
        public string ListarCitaxFiltro(string fechainicio = "", string fechafin = "", string modalidad = "", string idsucursal = "")
        {
            return _service.ListarCitaxFiltro(fechainicio, fechafin, modalidad, idsucursal);
        }
        [HttpPost("GuardarEditarCita")]
        public string GuardarEditarCita([FromBody] string jsoncita)
        {
            var rptaregistro = _service.GuardarEditarCita(jsoncita);
            return rptaregistro;
        }
        [HttpGet("ListarCitaAtenderxFiltro")]
        public string ListarCitaAtenderxFiltro(string fechainicio = "", string fechafin = "", string idmedico = "")
        {
            return _service.ListarCitaAtenderxFiltro(fechainicio, fechafin, idmedico);
        }
        [HttpPost("GuardarEditarCitaAtender")]
        public string GuardarEditarCitaAtender([FromBody] string jsoncita)
        {
            var rptaregistro = _service.GuardarEditarCitaAtender(jsoncita);
            return rptaregistro;
        }
        [HttpGet("ObtenerCitaAtenderxIdCita/{idcita}")]
        public string ObtenerCitaAtenderxIdCita(string idcita)
        {
            return _service.ObtenerCitaAtenderxIdCita(idcita);
        }
        [HttpPost("GuardarCitaArchivo")]
        public string GuardarCitaArchivo([FromBody] string jsoncitaarchivo)
        {
            var rptaregistro = _service.GuardarCitaArchivo(jsoncitaarchivo);
            return rptaregistro;
        }
        [HttpPost("EliminarCitaArchivo")]
        public string EliminarCitaArchivo([FromBody] string idcitaarchivo)
        {
            var rptaregistro = _service.EliminarCitaArchivo(idcitaarchivo);
            return rptaregistro;
        }
        [HttpGet("ObtenerHistorialClinicoxIdPaciente/{idpaciente}")]
        public string ObtenerHistorialClinicoxIdPaciente(string idpaciente)
        {
            return _service.ObtenerHistorialClinicoxIdPaciente(idpaciente);
        }
        [HttpGet("ObtenerCitaxIdCita_ModalCitasPaciente/{idcita}")]
        public string ObtenerCitaxIdCita_ModalCitasPaciente(string idcita)
        {
            return _service.ObtenerCitaxIdCita_ModalCitasPaciente(idcita);
        }
        [HttpGet("ObtenerDatosRecetaxIdReceta_FormatoReceta/{idcitaarchivo}")]
        public string ObtenerDatosRecetaxIdReceta_FormatoReceta(string idcitaarchivo)
        {
            return _service.ObtenerDatosRecetaxIdReceta_FormatoReceta(idcitaarchivo);
        }
        [HttpGet("ObtenerDisponibilidadCitaxIdCita/{idcita}")]
        public string ObtenerDisponibilidadCitaxIdCita(string idcita)
        {
            return _service.ObtenerDisponibilidadCitaxIdCita(idcita);
        }
        [HttpPost("ReprogramarCita")]
        public string ReprogramarCita([FromBody] string jsonreprogramarcita)
        {
            var rptaregistro = _service.ReprogramarCita(jsonreprogramarcita);
            return rptaregistro;
        }
        [HttpPost("EstadoNoRealizado")]
        public string EstadoNoRealizado([FromBody] string jsoncita)
        {
            var rptaregistro = _service.EstadoNoRealizado(jsoncita);
            return rptaregistro;
        }
        [HttpGet("ObtenerRecetaxIdReceta/{idreceta}")]
        public string ObtenerRecetaxIdReceta(string idreceta)
        {
            return _service.ObtenerRecetaxIdReceta(idreceta);
        }
        [HttpGet("ListarProductoTerminadoxFiltro")]
        public string ListarProductoTerminadoxFiltro(string filtro = "")
        {
            return _service.ListarProductoTerminadoxFiltro(filtro);
        }
        [HttpGet("ListarFormulaRapidaxFiltro")]
        public string ListarFormulaRapidaxFiltro(string filtro = "")
        {
            return _service.ListarFormulaRapidaxFiltro(filtro);
        }
        [HttpGet("ObtenerComposicionProductoXIdFormula/{idformula}")]
        public string ObtenerComposicionProductoXIdFormula(string idformula)
        {
            return _service.ObtenerComposicionProductoXIdFormula(idformula);
        }
        [HttpPost("GuardarEditarReceta")]
        public string GuardarEditarReceta([FromBody] string jsonreceta)
        {
            var rptaregistro = _service.GuardarEditarReceta(jsonreceta);
            return rptaregistro;
        }
        [HttpPost("EliminarReceta")]
        public string EliminarReceta([FromBody] string idreceta)
        {
            var rptaregistro = _service.EliminarReceta(idreceta);
            return rptaregistro;
        }
        [HttpGet("ListarInsumoxFiltro")]
        public string ListarInsumoxFiltro(string filtro = "")
        {
            return _service.ListarInsumoxFiltro(filtro);
        }
        [HttpPost("EditarHistorialClinico")]
        public string EditarHistorialClinico([FromBody] string jsonhistorialclinico)
        {
            var rptaregistro = _service.EditarHistorialClinico(jsonhistorialclinico);
            return rptaregistro;
        }
    }
}
