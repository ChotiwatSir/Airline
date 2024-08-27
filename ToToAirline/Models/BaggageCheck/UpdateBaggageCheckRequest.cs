
namespace ToToAirline.Models.BaggageCheck
{
    public class UpdateBaggageCheckRequest
    {
        public UpdateBaggageCheckRequest(string checkResult, Guid bookingId, Guid passengerId)
        {
            CheckResult = checkResult;
            BookingId = bookingId;
            PassengerId = passengerId;
        }

        public string CheckResult { get; set; }
        public Guid BookingId { get; set; }
        public Guid PassengerId { get; set; }
    }
}