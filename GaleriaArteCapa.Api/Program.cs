using GaleriaArteCapa.Domain.Services;
using GaleriaArteCapa.Infrastructure.Context;
using GaleriaArteCapa.Infrastructure.Core;
using GaleriaArteCapa.Infrastructure.Interfaces;
using GaleriaArteCapa.Infrastructure.Repositories;
using GaleriadeArte.Application.Contracts;
using GaleriadeArte.Application.Mapping;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped<IArtworkRepository, ArtworkRepository>();
builder.Services.AddScoped<IArtworkService, ArtworkService>();
builder.Services.AddScoped<IObrasDeArteRepository, ObrasDeArteRepository>();
builder.Services.AddScoped<IObrasDeArteService, ObrasDeArteService>();
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

app.UseAuthorization();

app.MapControllers();

app.Run();





