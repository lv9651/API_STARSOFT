using CLINICA_API.Areas.General.Service;
using Microsoft.AspNetCore.Mvc;

namespace CLINICA_API.Areas.General.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UbigeoController : ControllerBase
    {
        private readonly UbigeoService _service;
        public UbigeoController(UbigeoService service)
        {
            _service = service;
        }
        [HttpGet("ListarDepartamentos_Combo")]
        public string ListarDepartamentos_Combo()
        {
            return _service.ListarDepartamentos_Combo();
        }
        [HttpGet("ListarProvincias_Combo/{iddepartamento}")]
        public string ListarProvincias_Combo(string iddepartamento)
        {
            return _service.ListarProvincias_Combo(iddepartamento);
        }
        [HttpGet("ListarDistritos_Combo/{idprovincia}")]
        public string ListarDistritos_Combo(string idprovincia)
        {
            return _service.ListarDistritos_Combo(idprovincia);
        }
    }
}
