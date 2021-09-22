using System.Collections.Generic;
using MediatR;

namespace How2MediatR.Queries
{
    public class GetForecastByDaysQuery : IRequest<IEnumerable<WeatherForecast>>
    {
        public int Days { get; }

        public GetForecastByDaysQuery(int days)
        {
            Days = days;
        }
    }
}
