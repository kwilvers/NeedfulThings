namespace NeedfulThings.Application.DTOs;

public record WeatherDto(
    int Id, 
    DateOnly Date, 
    int TemperatureC, 
    string? Summary, 
    int RegionId, 
    string? RegionName);

public record WeatherCreateDto(
    DateOnly Date,
    int TemperatureC,
    string? Summary,
    int RegionId);
