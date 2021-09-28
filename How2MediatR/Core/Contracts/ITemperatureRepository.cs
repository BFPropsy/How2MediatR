using How2MediatR.Core.Model;

namespace How2MediatR.Core.Contracts
{
    public interface ITemperatureRepository
    {
        public TemperatureRange GetTemperatures(string location);
    }
}
