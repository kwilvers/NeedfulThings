using NeedfulThings.Domain.Entities;
using NeedfulThings.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace NeedfulThings.Infrastructure;

public class NeedfulThingsContext(DbContextOptions<NeedfulThingsContext> options) : DbContext(options)
{
    public DbSet<WeatherForecast> WeatherForecasts { get; set; } = null!;
    public DbSet<Region> Regions { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new WeatherForecastConfiguration());
        modelBuilder.ApplyConfiguration(new RegionConfiguration());
    }
}
