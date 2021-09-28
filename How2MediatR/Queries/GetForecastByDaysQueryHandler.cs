using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using How2MediatR.Contracts;

namespace How2MediatR.Queries
{
    public class GetForecastByDaysQueryHandler : IRequestHandler<GetForecastByDaysQuery, IEnumerable<WeatherForecast>>
    {
        private readonly ILogger<GetForecastByDaysQueryHandler> _logger;
        private readonly ITemperatureRepository _temperatureRepository;
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public GetForecastByDaysQueryHandler(ILogger<GetForecastByDaysQueryHandler> logger, ITemperatureRepository temperatureRepository)
        {
            _logger = logger;
            _temperatureRepository = temperatureRepository;
        }

        public Task<IEnumerable<WeatherForecast>> Handle(GetForecastByDaysQuery request, CancellationToken cancellationToken)
        {
            var temperatureRange = _temperatureRepository.GetTemperatures(request.Location);

            _logger.LogInformation("Sending request {@Request}", request);
            var rng = new Random();
            var result = Enumerable.Range(1, request.Days).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(temperatureRange.Low, temperatureRange.High),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
                .AsEnumerable();

            return Task.FromResult(result);
        }
    }
}
