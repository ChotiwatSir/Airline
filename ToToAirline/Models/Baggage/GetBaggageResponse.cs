
using ToToAirline.Models.Booking;

namespace ToToAirline.Models.Passenger.Baggage
{
    public class GetBaggageResponse
    {
        public GetBaggageResponse(Guid id, int weightInKg,GetBookingResponse? getBooking)
        {
            Id = id;
            WeightInKg = weightInKg;
            GetBookings = getBooking;

        }

        public Guid Id { get; }
        public int WeightInKg { get; }
        public GetBookingResponse? GetBookings { get; }

    }



}