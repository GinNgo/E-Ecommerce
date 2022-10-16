using E_Ecommerce_Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Ecommerce_Backend.Controllers
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

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
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
        [HttpGet("GetApi")]
        public IActionResult GetAllProducts()
        {
            var data = new List<ProductModel>()
            {
                new ProductModel(){ Id = 1, Name = "Product 1", Quantity = 10 },
                new ProductModel(){ Id = 2, Name = "Product 2", Quantity = 9 },
                new ProductModel(){ Id = 3, Name = "Product 3", Quantity = 8 }
            };

            return Ok(data.ToList());
        }
    }
}