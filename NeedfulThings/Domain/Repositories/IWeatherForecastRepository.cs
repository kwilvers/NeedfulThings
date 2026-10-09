using NeedfulThings.Domain.Entities;

namespace NeedfulThings.Domain.Repositories;

public interface IWeatherForecastRepository
{
    Task<IEnumerable<WeatherForecast>> GetAllAsync();
    Task<int> AddAsync(WeatherForecast entity);
    Task<WeatherForecast?> GetById(int id);
}
