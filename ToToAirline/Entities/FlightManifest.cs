namespace ToToAirline.Entities
{
    public class FlightManifest
    {
        public FlightManifest(Guid bookingId,Guid flightId)
        {
            Id = Guid.NewGuid();
            Create = DateTime.UtcNow;
            BookingId = bookingId;
            FlightId = flightId;
        }

        public Guid Id { get; set; }
        public DateTime Create { get; set; }
        public Booking Booking { get; set; } = null!;
        public Guid BookingId { get; set; }
        public Flight Flight { get; set; } = null!;
        public Guid FlightId { get; set; }
    }
}