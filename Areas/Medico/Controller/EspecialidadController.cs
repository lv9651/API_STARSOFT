using CLINICA_API.Areas.Medico.Service;
using Microsoft.AspNetCore.Mvc;

namespace CLINICA_API.Areas.Medico.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspecialidadController : ControllerBase
    {
        private readonly EspecialidadService _service;
        public EspecialidadController(EspecialidadService service)
        {
            _service = service;
        }

        [HttpGet("ListarEspecialidad_Combo")]
        public string ListarEspecialidad_Combo()
        {
            return _service.ListarEspecialidad_Combo();
        }
        [HttpGet("ListarEspecialidadXFiltro")]
        public async Task<string> ListarEspecialidadXFiltro(string filtro = "")
        {
            return await _service.ListarEspecialidadXFiltro(filtro);
        }
        [HttpGet("ObtenerEspecialidadxIdEspecialidad/{idespecialidad}")]
        public string ObtenerEspecialidadxIdEspecialidad(string idespecialidad)
        {
            return _service.ObtenerEspecialidadxIdEspecialidad(idespecialidad);
        }
        [HttpPost("GuardarEditarEspecialidad")]
        public string GuardarEditarEspecialidad([FromBody] string jsonespecialidad)
        {
            var rptaregistro = _service.GuardarEditarEspecialidad(jsonespecialidad);
            return rptaregistro;
        }
    }
}
