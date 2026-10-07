using NeedfulThings.Application.DTOs;
using NeedfulThings.Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace NeedfulThings.Application.Mappers;

[Mapper]
public partial class WeatherMapper
{
    public partial WeatherDto ToDto(WeatherForecast entity);

    [MapperIgnoreTarget(nameof(WeatherForecast.Region))]
    [MapperIgnoreSource(nameof(WeatherDto.RegionName))]
    public partial WeatherForecast ToEntity(WeatherDto dto);

    [MapperIgnoreTarget(nameof(WeatherForecast.Id))]
    [MapperIgnoreTarget(nameof(WeatherForecast.Region))]
    public partial WeatherForecast ToEntity(WeatherCreateDto dto);
}