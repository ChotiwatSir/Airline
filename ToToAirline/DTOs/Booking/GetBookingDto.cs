
using ToToAirline.DTOs.Passenger;

namespace ToToAirline.DTOs.Booking
{
    public class GetBookingDto
    {
        public GetBookingDto(Guid id, string flightId, bool status, string bookingPaltform,List<GetPassengerDto> passenger)
        {
            Id = id;
            FlightId = flightId;
            Status = status;
            BookingPaltform = bookingPaltform;
            Passengers = passenger;

        }

        public Guid Id { get; set; }
        public string FlightId { get; set; } = string.Empty;
        public bool Status { get; set; }
        public string BookingPaltform { get; set; } = string.Empty;
        public List<GetPassengerDto> Passengers { get; }
    }
}