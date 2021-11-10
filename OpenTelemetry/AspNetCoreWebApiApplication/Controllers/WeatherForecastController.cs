using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using AspNetCoreWebApiApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Npgsql;

namespace AspNetCoreWebApiApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching",
        };

        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, HttpClient httpClient, IConfiguration configuration)
        {
            this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _httpClient = httpClient;
            _configuration = configuration;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            using var scope = _logger.BeginScope("{Id}", Guid.NewGuid().ToString("N"));

            // Making an http call here to serve as an example of
            // how dependency calls will be captured and treated
            // automatically as child of incoming request.
            var res = _httpClient.GetStringAsync("http://google.com").Result;
            var rng = new Random();
            var forecast = Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)],
                })
                .ToArray();

            _logger.LogInformation(
                "WeatherForecasts generated {count}: {forecasts}",
                forecast.Length,
                forecast);

            using var connection = new NpgsqlConnection(_configuration.GetConnectionString("postgres"));
            using var command = connection.CreateCommand();
            command.CommandText = "select 1";
            connection.Open();
            var result = command.ExecuteScalar();



            return forecast;
        }
    }
}