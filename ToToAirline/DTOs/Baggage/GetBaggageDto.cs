using ToToAirline.DTOs.Booking;


namespace ToToAirline.DTOs.Baggage
{
    public class GetBaggageDto
    {
        public GetBaggageDto(Guid id, int weightInKg, GetBookingDto? getBookings)
        {
            Id = id;
            WeightInKg = weightInKg;
            GetBookings = getBookings;
        }

        public Guid Id { get;  }
        public int WeightInKg { get;  }
        public GetBookingDto? GetBookings { get;  }
    }
}