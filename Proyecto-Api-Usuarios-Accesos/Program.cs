using Microsoft.EntityFrameworkCore;
using Proyecto_Api_Usuarios_Accesos.Contexto;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Definimos el nuevo servicio en el contenedor de servicios que genera el contexto de conexion a base de datos 
builder.Services.AddDbContext<gestorBibliotecaDbContext>(
     o => o.UseNpgsql(builder.Configuration.GetConnectionString("CadenaConexionPostgreSQL")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Habilitar CORS
app.UseCors(builder =>
{
    builder.WithOrigins("http://localhost:4200") // Permite solicitudes desde este origen
           .AllowAnyHeader()
           .AllowAnyMethod();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
