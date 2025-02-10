using CLINICA_API.Areas.General.Service;
using Microsoft.AspNetCore.Mvc;

namespace CLINICA_API.Areas.General.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoController : ControllerBase
    {
        private readonly EstadoService _service;
        public EstadoController(EstadoService service)
        {
            _service = service;
        }
        [HttpGet("ListarEstadoxIdGrupoEstado/{idgrupoestado}")]
        public string ListarEstadoxIdGrupoEstado(string idgrupoestado)
        {
            return _service.ListarEstadoxIdGrupoEstado(idgrupoestado);
        }
    }
}
