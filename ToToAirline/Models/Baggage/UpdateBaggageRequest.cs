

namespace ToToAirline.Models.Baggage
{
    public class UpdateBaggageRequest
    {
        public UpdateBaggageRequest(int weightInKg, Guid bookingId)
        {
            WeightInKg = weightInKg;
            BookingId = bookingId;
        }

        public int WeightInKg { get; set; }
        public Guid BookingId { get; set; }
    }
}