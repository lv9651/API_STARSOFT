using CLINICA_API.Areas.General.Service;
using Microsoft.AspNetCore.Mvc;

namespace CLINICA_API.Areas.General.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentoController : ControllerBase
    {
        private readonly DocumentoService _service;
        public DocumentoController(DocumentoService service)
        {
            _service = service;
        }

        [HttpGet("ListarDocumento_Combo")]
        public string ListarDocumento_Combo()
        {
            return _service.ListarDocumento_Combo();
        }
    }
}
