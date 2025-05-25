

using STARSOFT_API.Areas.ORDER_COMPRA.Modelo;
using TuProyecto.Repositories;
using TuProyecto.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Service
builder.Services.AddScoped<InvoiceService>();
builder.Services.AddScoped<ImportacionService>();




//Data




builder.Services.AddScoped<InvoiceRepository>();
builder.Services.AddScoped<ImportacionRepository>();

//Conection



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
