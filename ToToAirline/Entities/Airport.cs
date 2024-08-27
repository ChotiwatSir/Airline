

namespace ToToAirline.Entities
{
    public class Airport
    {
        public Airport(string airportName, string county, string state, string city)
        {
            Id = Guid.NewGuid();
            AirportName = airportName;
            County = county;
            State = state;
            City = city;
            Create = DateTime.UtcNow;
        }

        public Guid Id { get; set; }
        public string AirportName { get; set; } = string.Empty;
        public string County { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public DateTime Create { get; set; }

        public Flight? ArrivingFlight { get; set; } 

        public Flight? DepartingFlight { get; set; } 

    }
}