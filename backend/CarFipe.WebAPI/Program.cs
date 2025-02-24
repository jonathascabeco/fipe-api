using CarFipe.Application.Services;
using CarFipe.Domain.Interfaces;
using CarFipe.Infrastructure.Data;
using CarFipe.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

builder.Services.AddControllers();

builder.Services.AddDbContext<CarFipeDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ICarRepository, CarRepository>();

builder.Services.AddHttpClient<FipeService>(); 

builder.Services.AddScoped<FipeService>();

var app = builder.Build();
app.MapControllers();
app.UseCors("AllowAllOrigins");
app.Run();