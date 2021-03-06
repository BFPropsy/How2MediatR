using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace How2MediatR.Queries
{
    public class GetByDaysQueryHandler : IRequestHandler<GetForecastByDaysQuery, IEnumerable<WeatherForecast>>
    {
        private readonly ILogger<GetByDaysQueryHandler> _logger;
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public GetByDaysQueryHandler(ILogger<GetByDaysQueryHandler> logger)
        {
            _logger = logger;
        }

        public Task<IEnumerable<WeatherForecast>> Handle(GetForecastByDaysQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Sending request {@Request} to IllustrationService", request);
            var rng = new Random();
            var result = Enumerable.Range(1, request.Days).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
                .AsEnumerable();

            return Task.FromResult(result);
        }
    }
}
