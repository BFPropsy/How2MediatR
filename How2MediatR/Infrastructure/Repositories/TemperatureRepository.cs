using How2MediatR.Core.Contracts;
using How2MediatR.Core.Model;
using How2MediatR.Infrastructure.Database;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace How2MediatR.Infrastructure.Repositories
{
    public class TemperatureRepository : ITemperatureRepository
    {
        public TemperatureRange GetTemperatures(string location)
        {
            var climates =
                from climateDto in DatabaseInMemory.LocationClimates
                where climateDto.Location == location
                select new TemperatureRange(climateDto.LowTemperature, climateDto.HighTemperature);
            // simulate real database response delay and async processing
            Task.Delay(2, CancellationToken.None);
            return climates.FirstOrDefault();
        }
    }
}
