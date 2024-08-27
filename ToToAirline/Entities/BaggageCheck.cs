
namespace ToToAirline.Entities
{
    public class BaggageCheck
    {
        public BaggageCheck( string checkResult, Guid bookingId, Guid passengerId)
        {
            Id = Guid.NewGuid();
            CheckResult = checkResult;
            BookingId = bookingId;
            PassengerId = passengerId;
            Create = DateTime.UtcNow;
        }

        public Guid Id { get; set; }
        public string CheckResult { get; set; } = string.Empty;
        public DateTime Create { get; set; }
        public Guid BookingId { get; set; }
        public Booking Booking { get; set; } = null!;
        
        public Passenger Passenger { get; set; } = null!;
        public Guid PassengerId { get; set; }
       

    }
}