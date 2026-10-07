namespace NeedfulThings.Domain.Entities;

public class Region
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public ICollection<WeatherForecast> WeatherForecasts { get; set; } = new List<WeatherForecast>();

}
