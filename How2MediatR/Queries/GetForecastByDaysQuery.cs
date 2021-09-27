using System.Collections.Generic;
using MediatR;

namespace How2MediatR.Queries
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
