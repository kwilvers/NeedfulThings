using Serilog;
using Microsoft.EntityFrameworkCore;
using NeedfulThings.Infrastructure;
using NeedfulThings.Application.Repositories;
using NeedfulThings.Infrastructure.Repositories;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSerilog((services, lc) =>
    lc.ReadFrom.Configuration(builder.Configuration));

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//Ajouter les Mappers au DI
builder.Services.AddSingleton<NeedfulThings.Application.Mappers.WeatherMapper>();
//Ajouter les service au DI
builder.Services.AddScoped<NeedfulThings.Application.Services.WeatherService>();
//Ajouter les repositories au DI
var connectionString = builder.Configuration.GetConnectionString("BazaarConnection");
builder.Services.AddDbContext<NeedfulThingsContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddScoped<IWeatherForecastRepository, WeatherForecastRepository>();

var app = builder.Build();

// Seed data
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<NeedfulThingsContext>();
    SeedData.Initialize(db);
}

app.UseSerilogRequestLogging();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
