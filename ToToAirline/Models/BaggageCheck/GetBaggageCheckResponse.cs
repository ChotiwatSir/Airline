
using ToToAirline.Models.Booking;

namespace ToToAirline.Models.BaggageCheck
{
    public class GetBaggageCheckResponse
    {
        public GetBaggageCheckResponse(Guid id, string checkResult, GetBookingResponse? getBooking)
        {
            Id = id;
            CheckResult = checkResult;
            GetBooking = getBooking;
        }

        public Guid Id { get;  }
        public string CheckResult { get; } 
        public GetBookingResponse? GetBooking { get;  }
    }
}