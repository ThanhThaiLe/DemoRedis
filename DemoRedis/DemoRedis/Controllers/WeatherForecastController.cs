using DemoRedis.Attributes;
using DemoRedis.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DemoRedis.Controllers
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

        private readonly IResponseCacheService _responseCacheService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IResponseCacheService responseCacheService)
        {
            _logger = logger;
            _responseCacheService = responseCacheService;
        }

        [HttpGet("getall")]
        [Cache(1000000000)]
        public async Task<IActionResult> GetAsync(string keyword = null, int pageIndex = 1, int pageSize = 10)
        {

            var result = new List<WeatherForecast>()
            {
                new WeatherForecast (){Name="Lê Thanh Thái 1"},
                new WeatherForecast (){Name="Lê Thanh Thái 2"},
                new WeatherForecast (){Name="Lê Thanh Thái 3"},
                new WeatherForecast (){Name="Lê Thanh Thái 4"},
                new WeatherForecast (){Name="Lê Thanh Thái 5"},
                new WeatherForecast (){Name="Lê Thanh Thái 6"},
            };
            return Ok(result);
        }


        [HttpGet("create")]
        public async Task<IActionResult> create()
        {
            await _responseCacheService.RemoveCacheResponseAsync("/weatherforecast/getall");

            return Ok();
        }
    }
}
