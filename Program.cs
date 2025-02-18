using CLINICA_API.Areas.Cita.Controller;
using CLINICA_API.Areas.Cita.Data;
using CLINICA_API.Areas.Cita.Service;
using CLINICA_API.Areas.Comercial.Controller;
using CLINICA_API.Areas.Comercial.Data;
using CLINICA_API.Areas.Comercial.Service;
using CLINICA_API.Areas.General.Controller;
using CLINICA_API.Areas.General.Data;
using CLINICA_API.Areas.General.Helpers;
using CLINICA_API.Areas.General.Service;
using CLINICA_API.Areas.Medico.Controller;
using CLINICA_API.Areas.Medico.Data;
using CLINICA_API.Areas.Medico.Service;
using CLINICA_API.Areas.Procedimiento.Controller;
using CLINICA_API.Areas.Procedimiento.Data;
using CLINICA_API.Areas.Procedimiento.Service;
using CLINICA_API.Areas.Producto.Controller;
using CLINICA_API.Areas.Producto.Data;
using CLINICA_API.Areas.Producto.Service;
using CLINICA_API.Areas.Usuario.Controller;
using CLINICA_API.Areas.Usuario.Data;
using CLINICA_API.Areas.Usuario.Service;
using CLINICA_API.Areas.Venta.Controller;
using CLINICA_API.Areas.Venta.Data;
using CLINICA_API.Areas.Venta.Service;
using SISLAB_API.Areas.Maestros.Repositories;
using SISLAB_API.Areas.Maestros.Services;
using YourNamespace.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("https://reservacita.vinali.pe")
                          .AllowAnyMethod()
                          .AllowAnyHeader()
                          .AllowCredentials());
});
//Service
builder.Services.AddScoped<MedicoService>();
builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<PermisoService>();
builder.Services.AddScoped<UsuarioPermisoService>();
builder.Services.AddScoped<RolPermisoService>();
builder.Services.AddScoped<RolService>();
builder.Services.AddScoped<ConstanteService>();
builder.Services.AddScoped<UbigeoService>();
builder.Services.AddScoped<EspecialidadService>();
builder.Services.AddScoped<ColegioService>();
builder.Services.AddScoped<ConsultorioService>();
builder.Services.AddScoped<ModalidadService>();
builder.Services.AddScoped<HorarioMedicoService>();
builder.Services.AddScoped<SucursalService>();
builder.Services.AddScoped<OrigenCitaService>();
builder.Services.AddScoped<ProcedenciaService>();
builder.Services.AddScoped<TipoEspecialidadService>();
builder.Services.AddScoped<TipoSangreService>();
builder.Services.AddScoped<CitaService>();
builder.Services.AddScoped<DiagnosticoService>();
builder.Services.AddScoped<PacienteService>();
builder.Services.AddScoped<DocumentoService>();
builder.Services.AddScoped<ListaPreciosService>();
builder.Services.AddScoped<EmpresaService>();
builder.Services.AddScoped<TipoProductoService>();
builder.Services.AddScoped<ProductoService>();
builder.Services.AddScoped<DocumentoTributarioService>();
builder.Services.AddScoped<ClienteService>();
builder.Services.AddScoped<TipoPagoService>();
builder.Services.AddScoped<TipoTarjetaService>();
builder.Services.AddScoped<ProcedimientoService>();
builder.Services.AddScoped<MotivoEmisionService>();
builder.Services.AddScoped<VentaService>();

builder.Services.AddScoped<UsuariosService>();
builder.Services.AddScoped<EmailService>();
builder.Services.AddScoped<MedicosService>();
builder.Services.AddControllers();
builder.Services.AddHttpClient<IzipayService>();
builder.Services.AddScoped<VentasService>();
builder.Services.AddScoped<CorreoService>();



//Data
builder.Services.AddScoped<MedicoData>();
builder.Services.AddScoped<UsuarioData>();
builder.Services.AddScoped<PermisoData>();
builder.Services.AddScoped<UsuarioPermisoData>();
builder.Services.AddScoped<RolPermisoData>();
builder.Services.AddScoped<RolData>();
builder.Services.AddScoped<ConstanteData>();
builder.Services.AddScoped<UbigeoData>();
builder.Services.AddScoped<EspecialidadData>();
builder.Services.AddScoped<ColegioData>();
builder.Services.AddScoped<ConsultorioData>();
builder.Services.AddScoped<ModalidadData>();
builder.Services.AddScoped<HorarioMedicoData>();
builder.Services.AddScoped<SucursalData>();
builder.Services.AddScoped<OrigenCitaData>();
builder.Services.AddScoped<ProcedenciaData>();
builder.Services.AddScoped<TipoEspecialidadData>();
builder.Services.AddScoped<TipoSangreData>();
builder.Services.AddScoped<CitaData>();
builder.Services.AddScoped<DiagnosticoData>();
builder.Services.AddScoped<PacienteData>();
builder.Services.AddScoped<DocumentoData>();
builder.Services.AddScoped<ListaPreciosData>();
builder.Services.AddScoped<EmpresaData>();
builder.Services.AddScoped<TipoProductoData>();
builder.Services.AddScoped<ProductoData>();
builder.Services.AddScoped<DocumentoTributarioData>();
builder.Services.AddScoped<ClienteData>();
builder.Services.AddScoped<TipoPagoData>();
builder.Services.AddScoped<TipoTarjetaData>();
builder.Services.AddScoped<ProcedimientoData>();
builder.Services.AddScoped<MotivoEmisionData>();
builder.Services.AddScoped<VentaData>();

builder.Services.AddScoped<UsuarioRepository>();
builder.Services.AddScoped<MedicoRepository>();
builder.Services.AddScoped<VentaRepository>();

//Conection
builder.Services.AddScoped<ServiceConnection>();
builder.Services.AddScoped<MedicoController>();
builder.Services.AddScoped<UsuarioController>();
builder.Services.AddScoped<PermisoController>();
builder.Services.AddScoped<UsuarioPermisoController>();
builder.Services.AddScoped<RolPermisoController>();
builder.Services.AddScoped<RolController>();
builder.Services.AddScoped<ConstanteController>();
builder.Services.AddScoped<UbigeoController>();
builder.Services.AddScoped<EspecialidadController>();
builder.Services.AddScoped<ColegioController>();
builder.Services.AddScoped<ConsultorioController>();
builder.Services.AddScoped<ModalidadController>();
builder.Services.AddScoped<HorarioMedicoController>();
builder.Services.AddScoped<SucursalController>();
builder.Services.AddScoped<OrigenCitaController>();
builder.Services.AddScoped<ProcedenciaController>();
builder.Services.AddScoped<TipoEspecialidadController>();
builder.Services.AddScoped<TipoSangreController>();
builder.Services.AddScoped<CitaController>();
builder.Services.AddScoped<DiagnosticoController>();
builder.Services.AddScoped<PacienteController>();
builder.Services.AddScoped<DocumentoController>();
builder.Services.AddScoped<ListaPreciosController>();
builder.Services.AddScoped<EmpresaController>();
builder.Services.AddScoped<TipoProductoController>();
builder.Services.AddScoped<ProductoController>();
builder.Services.AddScoped<DocumentoTributarioController>();
builder.Services.AddScoped<ClienteController>();
builder.Services.AddScoped<TipoPagoController>();
builder.Services.AddScoped<TipoTarjetaController>();
builder.Services.AddScoped<ProcedimientoController>();
builder.Services.AddScoped<MotivoEmisionController>();
builder.Services.AddScoped<VentaController>();

var app = builder.Build();

app.UseCors("AllowSpecificOrigin");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
