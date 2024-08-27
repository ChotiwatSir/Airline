
using ToToAirline.Models.Passenger;

namespace ToToAirline.Models.Booking
{
    public class GetBookingResponse
    {
        public GetBookingResponse(Guid id, string flightId, bool status, string bookingPaltform, List<GetPassengerResponse>? getPassengers)
        {
            Id = id;
            FlightId = flightId;
            Status = status;
            BookingPaltform = bookingPaltform;
            GetPassengers = getPassengers;
        }

        public Guid Id { get; }
        public string FlightId { get; } = string.Empty;
        public bool Status { get; }
        public string BookingPaltform { get; } = string.Empty;
        public List<GetPassengerResponse>? GetPassengers{ get; }
    }
}