using ToToAirline.DTOs.FlightManiFest;

namespace ToToAirline.IService
{
    public interface IFlightManiFestService
    {
        public GetFlightManiFestDto GetFlightManiFest(Guid bookingId,Guid flightId);
        public void CreateFlightManifest(CreateFlightManifestDto create);
    }
}