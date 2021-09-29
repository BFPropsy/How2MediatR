using How2MediatR.Core.Model;
using How2MediatR.Core.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace How2MediatR.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WeatherForecastController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> GetAsync(int days, string location)
        {
            var response = await _mediator.Send(new GetForecastByDaysQuery(days, location));
            return response;
        }
    }
}
