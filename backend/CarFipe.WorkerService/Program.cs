using CarFipe.Application.Services;
using CarFipe.Domain.Interfaces;
using CarFipe.Infrastructure.Data;
using CarFipe.Infrastructure.Repositories;
using CarFipe.WorkerService;
using Hangfire;
using Microsoft.EntityFrameworkCore;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddHttpClient<FipeService>();

builder.Services.AddDbContext<CarFipeDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ICarRepository, CarRepository>();

builder.Services.AddScoped<FipeService>();

builder.Services.AddHangfire(config =>
{
    config.UseSqlServerStorage(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddHangfireServer();

builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();