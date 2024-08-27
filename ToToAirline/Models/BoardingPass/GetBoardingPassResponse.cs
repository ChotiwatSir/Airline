using ToToAirline.Models.Booking;

namespace ToToAirline.Models.BoardingPass
{
    public class GetBoardingPassResponse
    {
        public GetBoardingPassResponse(Guid id, int qRCode, GetBookingResponse? getBooking)
        {
            Id = id;
            QRCode = qRCode;
            GetBooking = getBooking;
        }

        public Guid Id { get; }
        public int QRCode { get;  }
        public GetBookingResponse? GetBooking { get;}
    }
}