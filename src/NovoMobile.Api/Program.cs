using Microsoft.EntityFrameworkCore;
using NovoMobile.Api.Data;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

// Servi�os
builder.Services.AddControllers(); // Chamada para os controllers
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Config Entity Framework Core e SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Configura��o do aplicativo
var app = builder.Build();

// Configura��o do pipeline de requisi��es HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();

