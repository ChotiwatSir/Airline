using ToToAirline.DTOs.Booking;

namespace ToToAirline.DTOs.BoardingPass
{
    public class GetBoardingPassDto
    {
        public GetBoardingPassDto(Guid id, int qRCode, GetBookingDto? booking)
        {
            Id = id;
            QRCode = qRCode;
            Booking = booking;
        }

        public Guid Id { get; set; }
        public int QRCode { get; set; }
        public GetBookingDto? Booking{ get; set; }
    }
}