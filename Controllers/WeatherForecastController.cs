using Microsoft.AspNetCore.Mvc;

namespace LogitoErgoSum.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        //_logger.Log(LogLevel.Information, "loggin message at information level");
        //_logger.LogInformation("Loging message variant at info level");
        _logger.LogTrace("log message at trace level");
        _logger.LogInformation(EventIds.LoginEvent, $"evetnid : {EventIds.LoginEvent};  login_event_id used at loginfo level");
        try
        {
            _logger.LogInformation("logging message with args: today is {x}, time is {y}", DateTime.Now.DayOfWeek, DateTime.Now.ToLongTimeString());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "smtng is wrong while args logging");
        }


        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}
