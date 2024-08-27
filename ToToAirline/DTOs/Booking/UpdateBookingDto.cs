namespace ToToAirline.DTOs.Booking
{
    public class UpdateBookingDto
    {
        public UpdateBookingDto(string flightId, bool status, string bookingPaltform, Guid passengerId)
        {
            FlightId = flightId;
            Status = status;
            BookingPaltform = bookingPaltform;
            PassengerId = passengerId;
        }

        public string FlightId { get; set; } = string.Empty;
        public bool Status { get; set; }
        public string BookingPaltform { get; set; } = string.Empty;
        public Guid PassengerId { get; set; }
    }
}