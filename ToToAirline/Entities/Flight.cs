namespace ToToAirline.Entities
{
    public class Flight
    {
        public Flight(string departureGate, string arrivingGate, Guid airlineId, Guid departureAirportId, Guid arrivingAirportId)
        {
            Id = Guid.NewGuid();
            DepartureGate = departureGate;
            ArrivingGate = arrivingGate;
            AirlineId = airlineId;
            DepartureAirportId = departureAirportId;
            ArrivingAirportId = arrivingAirportId;
            Create = DateTime.UtcNow;
        }

        public Guid Id { get; set; }
        public string DepartureGate { get; set; } = string.Empty;
        public string ArrivingGate { get; set; } = string.Empty;
        public DateTime Create { get; set; }
        public Guid AirlineId { get; set; }
        public Airline Airline { get; set; } = null!;
        public Airport ArrivingAirport { get; set; } = null!;
        public Guid ArrivingAirportId { get; set; }

        public Airport DepartingAirport { get; set; } = null!;
        public Guid DepartureAirportId { get; set; }
        public ICollection<FlightManifest> FlightManifests { get; set; } = new List<FlightManifest>();

    }
}