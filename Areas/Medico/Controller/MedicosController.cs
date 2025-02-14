using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using SISLAB_API.Areas.Maestros.Models;
using SISLAB_API.Areas.Maestros.Services;
using System.Web;





namespace SISLAB_API.Areas.Maestros.Controllers // Cambia esto al espacio de nombres real
{

    [Route("api/[controller]")]
[ApiController]
public class MedicosController : ControllerBase
{
    private readonly MedicosService _medicoService;

    public MedicosController(MedicosService medicoService)
    {
            _medicoService = medicoService;
    }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Medico>>> GetEspecialidades()
        {
            var especialidades = await _medicoService.ObtenerEspecialidadesAsync();
            return Ok(especialidades);
        }


        [HttpGet("buscarSucursal/")]
        public async Task<ActionResult<IEnumerable<Sucursal>>> GetSucursales()
        {
            var sucursales = await _medicoService.ObtenerSucursalesAsync();
            return Ok(sucursales);
        }



        [HttpGet("buscar/{descripcion}")]
        public async Task<IActionResult> BuscarMedicoPorEspecialidad(string descripcion)
        {
            if (string.IsNullOrEmpty(descripcion))
            {
                return BadRequest("La descripción de la especialidad es requerida.");
            }

            // Llamar al servicio para obtener los médicos
            var medicos = await _medicoService.BuscarMedicoPorEspecialidadAsync(descripcion);

           

            return Ok(medicos);
        }



        [HttpGet("buscar_dependiente/{dni}")]
        public async Task<IActionResult> BuscarDependiente(string dni)
        {
            if (string.IsNullOrEmpty(dni))
            {
                return BadRequest("La descripción de la especialidad es requerida.");
            }

            // Llamar al servicio para obtener los médicos
            var medicos = await _medicoService.BuscarDependiente(dni);



            return Ok(medicos);
        }



        [HttpGet("Act_Hist_cli/{nrodocumento}")]
        public async Task<IActionResult> ActHistCli(string nrodocumento,string email, string clave)
        {
            if (string.IsNullOrEmpty(nrodocumento))
            {
                return BadRequest("El dni es requerido.");
            }

            // Llamar al servicio para obtener los médicos
            var medicos = await _medicoService.ActHistCli(nrodocumento,email,clave);



            return Ok(medicos);
        }
        [HttpGet("buscar_idpaciente/{dni}")]
        public async Task<IActionResult> BuscarIdpaciente(string dni)
        {
            if (string.IsNullOrEmpty(dni))
            {
                return BadRequest("La descripción de la especialidad es requerida.");
            }

            // Llamar al servicio para obtener los médicos
            var medicos = await _medicoService.BuscarIdpaciente(dni);



            return Ok(medicos);
        }


        [HttpGet("buscarcita/{documento}")]
        public async Task<IActionResult> BuscarCitaPorCliente(string documento)
        {
            if (string.IsNullOrEmpty(documento))
            {
                return BadRequest("La descripción de la especialidad es requerida.");
            }

            // Llamar al servicio para obtener los médicos
            var medicos = await _medicoService.Busq_cita_clienteAsync(documento);



            return Ok(medicos);
        }


        [HttpGet("buscarhistorialMedico/{documento}")]
        public async Task<IActionResult> BuscarHistorialMedico(string documento)
        {
            if (string.IsNullOrEmpty(documento))
            {
                return BadRequest("La descripción de la especialidad es requerida.");
            }

            // Llamar al servicio para obtener los médicos
            var medicos = await _medicoService.Busq_historial_clinico(documento);



            return Ok(medicos);
        }

        [HttpGet("buscapacientedependiente/{documento}")]
        public async Task<IActionResult> BuscarPacienteDependiente(string documento)
        {
            if (string.IsNullOrEmpty(documento))
            {
                return BadRequest("La descripción de la especialidad es requerida.");
            }

            // Llamar al servicio para obtener los médicos
            var medicos = await _medicoService.Busq_dependientePaciente(documento);



            return Ok(medicos);
        }





        [HttpGet("buscardia/{colegio}")]
    public async Task<IActionResult> BuscardiaMedicoAsync(string colegio)
    {
        if (string.IsNullOrEmpty(colegio))
        {
            return BadRequest("La descripción de la especialidad es requerida.");
        }

        // Llamar al servicio para obtener los médicos
        var medicos = await _medicoService.BuscardiaMedicoAsync(colegio);



        return Ok(medicos);
    }





        [HttpGet("ObtenerTipoPago/")]
        public async Task<ActionResult<IEnumerable<Tipo_pago>>> GetTipopago()
        {
            var Tipopago = await _medicoService.ObtenerTipopago();
            return Ok(Tipopago);
        }



        [HttpPost("insertar-familiar")]
        public async Task<IActionResult> InsertarPacienteFamiliar([FromBody] Reg_pariente request)
        {
            try
            {
                // Llamamos al servicio para insertar el paciente y obtener el cli_codigo
                int cliCodigo = await _medicoService.InsertarPacienteFamiliarAsync(request);

                // Retornar el cli_codigo insertado en una respuesta exitosa
                return Ok(new { cli_codigo = cliCodigo });
            }
            catch (Exception ex)
            {
                // Si ocurre un error, devolver el mensaje de error
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("Act_cli_Vin")]
        public async Task<IActionResult> ActualizarDatosVinali([FromBody] Reg_pariente request)
        {
            try
            {
                // Validate the input data if necessary
                if (request == null)
                {
                    return BadRequest(new { message = "Request body cannot be null" });
                }

                // Call the service to insert the patient and retrieve the cli_codigo
                int cliCodigo = await _medicoService.ActclienteVinAsync(request);

                // If cliCodigo is 0 or an invalid result, return a bad request
                if (cliCodigo <= 0)
                {
                    return BadRequest(new { message = "Failed to retrieve cli_codigo" });
                }

                // Return the cli_codigo in the successful response
                return Ok(new { cli_codigo = cliCodigo });
            }
            catch (Exception ex)
            {
                // Log the exception if necessary
                // _logger.LogError(ex, "Error while processing Act_cli_Vin request.");

                // Return an error message
                return BadRequest(new { message = ex.Message });
            }
        }







        [HttpPost("buscardiahora")]
        public async Task<IActionResult> BuscardiaHoraMedico([FromBody] BusquedaRequest request)
        {
            if (string.IsNullOrEmpty(request.Fecha) || string.IsNullOrEmpty(request.Colegio) || string.IsNullOrEmpty(request.idmodalidad))
            {
                return BadRequest("Los parámetros 'fecha' y 'colegio' son requeridos.");
            }

            try
            {
                var resultados = await _medicoService.BuscardiaHoraMedicoAsync(request.Fecha, request.Colegio, request.idmodalidad);
                return Ok(resultados);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al ejecutar la consulta: {ex.Message}");
            }
        }




        [HttpPost("buscarPrecio")]
        public async Task<IActionResult> BuscarPrecio([FromBody] BusquedaPrecio request)
        {
            if (string.IsNullOrEmpty(request.especialidad) ||  request.idsucursal < 0)
            {
                return BadRequest("Los parámetros 'especialidad' y 'sucursal' son requeridos.");
            }

            try
            {
                var resultados = await _medicoService.BuscarPrecioAsync(request.especialidad, request.idsucursal);
                return Ok(resultados);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al ejecutar la consulta: {ex.Message}");
            }
        }
    }
}