using NeedfulThings.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace NeedfulThings.Infrastructure;

public static class SeedData
{
    public static void Initialize(NeedfulThingsContext context)
    {
        if (context == null) throw new ArgumentNullException(nameof(context));

        // Ensure database created (works for InMemory and relational providers)
        context.Database.EnsureCreated();

        if (context.Regions.Any())
        {
            return; // DB has been seeded
        }

        var regions = new List<Region>
        {
            new Region {Name = "Nord"},
            new Region {Name = "Sud"},
            new Region {Name = "Est"},
            new Region {Name = "Ouest"}
        };

        context.Regions.AddRange(regions);
        context.SaveChanges();

        var forecasts = new List<WeatherForecast>();
        var rng = new Random(42);
        foreach (var region in regions)
        {
            for (int i = 1; i <= 3; i++)
            {
                forecasts.Add(new WeatherForecast
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(i)),
                    TemperatureC = rng.Next(-10, 35),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)],
                    RegionId = region.Id
                });
            }
        }

        context.WeatherForecasts.AddRange(forecasts);
        context.SaveChanges();
    }

    private static readonly string[] Summaries =
    [
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    ];
}
