namespace ToToAirline.Entities
{
    public class Booking
    {
        public Booking(string flightId, bool status, string bookingPaltform , Guid passengerId)
        {
            Id = Guid.NewGuid();
            FlightId = flightId;
            Status = status;
            BookingPaltform = bookingPaltform;
            PassengerId = passengerId;
            Create = DateTime.UtcNow;
        }

        public Guid Id { get; set; }
        public string FlightId { get; set; } = string.Empty;
        public bool Status { get; set; }
        public string BookingPaltform { get; set; } = string.Empty;
        public DateTime Create { get; set; }
        public Guid PassengerId { get; set; }
        public Passenger Passenger { get; set; } = null!;
        public ICollection<FlightManifest> FlightManifests { get; set; } = new List<FlightManifest>();
        public ICollection<Baggage> Baggages { get; set; } = new List<Baggage>();
        public ICollection<BaggageCheck> BaggageChecks { get; set; } = new List<BaggageCheck>();
        public ICollection<BoardingPass> BoardingPasses { get; set; } = new List<BoardingPass>();
    }
}