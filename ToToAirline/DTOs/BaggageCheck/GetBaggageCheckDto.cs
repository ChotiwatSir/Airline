using ToToAirline.DTOs.Booking;

namespace ToToAirline.DTOs.BaggageCheck
{
    public class GetBaggageCheckDto
    {
        public GetBaggageCheckDto(Guid id, string checkResult, GetBookingDto? getBookingDto)
        {
            Id = id;
            CheckResult = checkResult;
            GetBookingDto = getBookingDto;
            
        }

        public Guid Id { get;  }
        public string CheckResult { get;  } = string.Empty;
        public GetBookingDto? GetBookingDto { get;  }

    }
}