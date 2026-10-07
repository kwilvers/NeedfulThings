using NeedfulThings.Application.DTOs;
using NeedfulThings.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace NeedfulThings.Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController(WeatherService service, ILogger<WeatherForecastController> logger)
    : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<WeatherDto>>> GetAll()
    {
        logger.LogInformation("GET WeatherForecast");
        var items = await service.GetAll();
        return Ok(items);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<WeatherDto>> GetById(int id)
    {
        logger.LogInformation("GET WeatherForecast: {@Id}", id);
        var item = await service.GetById(id);
        if (item == null)
            return NotFound();
        return Ok(item);
    }

    [HttpPost]
    public async Task<ActionResult<WeatherDto>> Post([FromBody] WeatherCreateDto dto)
    {
        logger.LogInformation("POST WeatherForecast: {@dto}", dto);

        int idEntity = await service.Add(dto);
        var item = await service.GetById(idEntity);
        if (item == null)
            return NotFound();

        return CreatedAtAction(nameof(GetById), new { id = idEntity }, item);
    }
}
