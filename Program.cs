using CLINICA_API.Areas.General.Helpers;
using CLINICA_API.Areas.Medico.Data;
using CLINICA_API.Areas.Medico.Service;
using CLINICA_API.Areas.Usuario.Controller;
using CLINICA_API.Areas.Usuario.Data;
using CLINICA_API.Areas.Usuario.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Service
builder.Services.AddScoped<MedicoService>();
builder.Services.AddScoped<UsuarioService>();
//Data
builder.Services.AddScoped<MedicoData>();
builder.Services.AddScoped<UsuarioData>();
//Conection
builder.Services.AddScoped<ServiceConnection>();
builder.Services.AddScoped<UsuarioController>();

var app = builder.Build();


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
