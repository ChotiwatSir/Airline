
using ToToAirline.Models.Booking;
using ToToAirline.Models.Flight;

namespace ToToAirline.Models.FlightManifest
{
    public class GetFlightManifestResponse
    {
        public GetFlightManifestResponse(Guid bookingId, Guid flightId, GetBookingResponse? bookingResponse, GetFlightResponse? flightResponse)
        {
            BookingId = bookingId;
            FlightId = flightId;
            BookingResponse = bookingResponse;
            FlightResponse = flightResponse;
        }

        public Guid Id { get;  }
        public Guid BookingId { get;  }
        public Guid FlightId { get;  }
        public GetBookingResponse? BookingResponse { get;  }
        public GetFlightResponse? FlightResponse { get;  }
    }
}