
namespace ToToAirline.DTOs.Baggage
{
    public class CreateBaggageDto
    {
        public CreateBaggageDto(int weightInKg,Guid bookingId)
        {
            WeightInKg = weightInKg;
            BookingId = bookingId;
        }

        public int WeightInKg { get; set; }
        public Guid BookingId { get; set; }
    }
}