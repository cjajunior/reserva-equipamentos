using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Reserva.Infrastructure.Data;
using Reserva.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Serviços da aplicação
builder.Services.AddControllers(); // ✅ Isso habilita os controllers
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ReservaService>();
builder.Services.AddHttpClient();


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Endpoint de status
app.MapGet("/", () => Results.Json(new
{
    status = "online",
    api = "Reserva.API",
    version = "1.0",
    message = "Seja bem-vindo à API de Reservas 👋"
}));

app.UseHttpsRedirection();

// ✅ Habilita os endpoints dos controllers
app.MapControllers(); 

app.Run();
