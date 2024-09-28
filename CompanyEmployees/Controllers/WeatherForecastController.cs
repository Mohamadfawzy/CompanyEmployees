using Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CompanyEmployees.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ILoggerManager logger2;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ILoggerManager logger2)
        {
            _logger = logger;
            this.logger2 = logger2;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            logger2. LogInfo("Here is info message from our values controller.");
            logger2.LogDebug("Here is debug message from our values controller.");
            logger2.LogWarn("Here is warn message from our values controller.");
            logger2.LogError("Here is an error message from our values controller.");

            _logger.LogInformation("LogInformation");
            _logger.LogWarning("LogWarning");
            _logger.LogError("LogError");
            _logger.LogCritical("LogCritical");
            _logger.LogDebug("LogDebug");

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
