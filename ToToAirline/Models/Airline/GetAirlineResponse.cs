
namespace ToToAirline.Models.Passenger.Airline
{
    public class GetAirlineResponse
    {
        public GetAirlineResponse(Guid id, string airlineCode, string airlineName, string airlineCounty)
        {
            Id = id;
            AirlineCode = airlineCode;
            AirlineName = airlineName;
            AirlineCounty = airlineCounty;
        }

        public Guid Id { get; }
        public string AirlineCode { get;  }
        public string AirlineName { get; } 
        public string AirlineCounty { get; }
    }
}