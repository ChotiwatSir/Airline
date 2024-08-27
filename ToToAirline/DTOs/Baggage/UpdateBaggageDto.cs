
namespace ToToAirline.DTOs.Baggage
{
    public class UpdateBaggageDto
    {
        public UpdateBaggageDto(int weightInKg, Guid bookingId)
        {
            WeightInKg = weightInKg;
            BookingId = bookingId;
        }

        public int WeightInKg { get; set; }
        public Guid BookingId { get; set; }
    }
}