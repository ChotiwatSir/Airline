using ToToAirline.DTOs.Booking;
using ToToAirline.DTOs.Flight;

namespace ToToAirline.DTOs.FlightManiFest
{
    public class GetFlightManiFestDto
    {
        public GetFlightManiFestDto(Guid id, Guid bookingId, Guid flightId, GetBookingDto? bookingDto, GetFlightDto? flightDto)
        {
            Id = id;
            BookingId = bookingId;
            FlightId = flightId;
            BookingDto = bookingDto;
            FlightDto = flightDto;
        }

        public Guid Id { get; }
        public Guid BookingId { get; }
        public Guid FlightId { get; }
        public GetBookingDto? BookingDto { get; }
        public GetFlightDto? FlightDto { get; }
        

    }
}