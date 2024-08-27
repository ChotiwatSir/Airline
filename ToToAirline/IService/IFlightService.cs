using ToToAirline.DTOs.Flight;

namespace ToToAirline.IService
{
    public interface IFlightService
    {
        public List<GetFlightDto> GetFlights();
        public void CreateFlight(CreateFlightDto create);
        public void UpdateFlight(Guid flightId,UpdateFlightDto update);
        public void DeleteFlight(Guid flightId);
    }
}