using NeedfulThings.Domain.Entities;

namespace NeedfulThings.Application.Repositories;

public interface IWeatherForecastRepository
{
    Task<IEnumerable<WeatherForecast>> GetAllAsync();
    Task<int> AddAsync(WeatherForecast entity);
    Task<WeatherForecast?> GetById(int id);
}
