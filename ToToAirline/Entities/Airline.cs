
namespace ToToAirline.Entities
{
    public class Airline
    {
        public Airline( string airlineCode, string airlineName, string airlineCounty)
        {
            Id = Guid.NewGuid();
            AirlineCode = airlineCode;
            AirlineName = airlineName;
            AirlineCounty = airlineCounty;
            CreateAt = DateTime.UtcNow;
        }

        public Guid Id { get; set; }
        public string AirlineCode { get; set; } = string.Empty;
        public string AirlineName { get; set; } = string.Empty;
        public string AirlineCounty { get; set; } = string.Empty;
        public DateTime CreateAt { get; set; }
        public ICollection<Flight> Flights { get; set; } = new List<Flight>();
    }
}