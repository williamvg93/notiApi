using System.Reflection;
using Api.Extensions;
using AspNetCoreRateLimit;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/* Necesario para agregar los Cors IUnitOfWork */
builder.Services.ConfigureCors();
/* Necesario para la IUnitOfWork */
builder.Services.AddAplicationServices();
/* Extension necesaria para limitar número de peticiones */
builder.Services.ConfigureRatelimiting();

/* Necesario para el AutoMapper */
builder.Services.AddAutoMapper(Assembly.GetEntryAssembly());

builder.Services.AddDbContext<NotiApiContext>(options =>
{
    string connectionStrings = builder.Configuration.GetConnectionString("MysqlConec");
    options.UseMySql(connectionStrings, ServerVersion.AutoDetect(connectionStrings));
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

/* Implementación de las Cors */
app.UseCors("CorsPolicy");

/* Implementación del RateLimit */
app.UseIpRateLimiting();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
