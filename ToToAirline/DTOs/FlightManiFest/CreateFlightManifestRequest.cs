
namespace ToToAirline.DTOs.FlightManiFest
{
    public class CreateFlightManifestDto
    {
        public CreateFlightManifestDto(Guid bookingId, Guid flightId)
        {
            BookingId = bookingId;
            FlightId = flightId;
        }

        public Guid BookingId { get; set; }
        public Guid FlightId { get; set; }
    }
}