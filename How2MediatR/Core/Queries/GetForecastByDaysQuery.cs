using System.Collections.Generic;
using How2MediatR.Core.Model;
using MediatR;

namespace How2MediatR.Core.Queries
{
    public class GetForecastByDaysQuery : IRequest<IEnumerable<WeatherForecast>>
    {
        public int Days { get; }
        public string Location { get; }

        public GetForecastByDaysQuery(int days, string location)
        {
            Days = days;
            Location = location;
        }
    }
}
