
namespace ToToAirline.DTOs.BaggageCheck
{
    public class CreateBaggageCheckDto
    {
        public CreateBaggageCheckDto(string checkResult, Guid bookingId, Guid passengerId)
        {
            CheckResult = checkResult;
            BookingId = bookingId;
            PassengerId = passengerId;
        }

        public string CheckResult { get; set; } = string.Empty;
        public Guid BookingId { get; set; }
        public Guid PassengerId { get; set; }
    }
}