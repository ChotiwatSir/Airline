namespace ToToAirline.Entities
{
    public class BoardingPass
    {
        public BoardingPass(int qRCode, Guid bookingId)
        {
            Id = Guid.NewGuid();
            QRCode = qRCode;
            Create = DateTime.UtcNow;
            BookingId = bookingId;
        }

        public Guid Id { get; set; }
        public int QRCode { get; set; }
        public DateTime Create { get; set; }
        public Guid BookingId { get; set; }
        public Booking Booking { get; set; } = null!;
    }
}