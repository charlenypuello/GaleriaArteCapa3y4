using GaleriaArteCapa.Application.Contracts;
using GaleriaArteCapa.Application.Mapping;
using GaleriaArteCapa.Application.Services;
using GaleriaArteCapa.Infrastructure.Context;
using GaleriaArteCapa.Infrastructure.Core;
using GaleriaArteCapa.Infrastructure.Interfaces;
using GaleriaArteCapa.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy
            .AllowAnyOrigin()   // Permitir cualquier origen
            .AllowAnyMethod()   // Permitir cualquier método (GET, POST, PUT, DELETE, etc.)
            .AllowAnyHeader();  // Permitir cualquier cabecera
    });
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped<IInteraccioneRepository, InteraccioneRepository>();
builder.Services.AddScoped<IInteraccioneService, InteraccioneService>();

builder.Services.AddScoped<IObraRepository, ObraRepository>();
builder.Services.AddScoped<IObraService, ObraService>();

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();

builder.Services.AddDbContext<GADbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthorization();

app.MapControllers();

app.Run();





