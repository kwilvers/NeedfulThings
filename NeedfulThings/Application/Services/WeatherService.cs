using NeedfulThings.Application.DTOs;
using NeedfulThings.Application.Mappers;
using NeedfulThings.Application.Repositories;
using NeedfulThings.Domain.Entities;

namespace NeedfulThings.Application.Services;

public class WeatherService(IWeatherForecastRepository repository, WeatherMapper mapper, ILogger<WeatherService> logger)
{
    public async Task<IEnumerable<WeatherDto>> GetAll()
    {
        logger.LogInformation("GetAll...");
        var entities = await repository.GetAllAsync();
        var dtos = entities.Select(e => mapper.ToDto(e));

        return dtos;
    }

    public async Task<int> Add(WeatherCreateDto dto)
    {
        logger.LogInformation("Add WeatherForecast: {@dto}", dto);
        var entity = mapper.ToEntity(dto);
        return await repository.AddAsync(entity);
    }

    public async Task<WeatherDto?> GetById(int id)
    {
        var entity =  await repository.GetById(id);
        return entity != null ? mapper.ToDto(entity) : null;
    }
}