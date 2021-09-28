namespace How2MediatR.Contracts
{
    public interface ITemperatureRepository
    {
        public TemperatureRange GetTemperatures(string location);
    }
}
