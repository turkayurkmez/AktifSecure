using Microsoft.AspNetCore.Mvc;

namespace DataProtectionInServer.Controllers
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
        private readonly IHostEnvironment hostBuilder;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IHostEnvironment environment)
        {
            _logger = logger;
            hostBuilder = environment;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {

            string data = "Bu cümle; gizli bir cümle";
            DataProtector dataProtector = new DataProtector(hostBuilder.ContentRootPath);
            var length = dataProtector.EncryptData(data);

            var cozulenVeri = dataProtector.DecryptData(length);

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}