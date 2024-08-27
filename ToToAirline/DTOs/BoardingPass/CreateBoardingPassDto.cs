
namespace ToToAirline.DTOs.BoardingPass
{
    public class CreateBoardingPassDto
    {
        public CreateBoardingPassDto(int qRCode)
        {
            QRCode = qRCode;
        }

        public int QRCode { get; set; }
    }
}