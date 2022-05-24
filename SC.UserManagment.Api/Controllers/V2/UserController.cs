using Microsoft.AspNetCore.Mvc;

namespace SC.UserManagment.Api.Controllers.V2;

/// <summary>
/// 
/// </summary>
[ApiController]
[ApiVersion("2")]
[Route("api/v{version:apiVersion}/[controller]")]
public class UserController : ControllerBase
{
  private static readonly string[] Summaries = new[]
  {
      "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
  };

  private readonly ILogger<UserController> _logger;

  /// <summary>
  /// 
  /// </summary>
  /// <param name="logger"></param>
  public UserController(ILogger<UserController> logger)
  {
    _logger = logger;
  }

  /// <summary>
  /// 
  /// </summary>
  /// <returns></returns>
  [HttpGet(Name = "GetWeatherForecast")]
  [Produces("application/json")]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(WeatherForecast[]))]
  public IEnumerable<WeatherForecast> Get()
  {
    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
    {
      Date = DateTime.Now.AddDays(index),
      TemperatureC = Random.Shared.Next(-20, 55),
      Summary = Summaries[Random.Shared.Next(Summaries.Length)]
    })
    .ToArray();
  }
}
