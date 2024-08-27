

namespace ToToAirline.Models.Passenger.Baggage
{
    public class CreateBaggageRequest
    {
        public CreateBaggageRequest(int weightInKg,Guid bookingId)
        {
            WeightInKg = weightInKg;
            BookingId = bookingId;
        }

        public int WeightInKg { get; set; }
        public Guid BookingId { get; set; }
    }
}