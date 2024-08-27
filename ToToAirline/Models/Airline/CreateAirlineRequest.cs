
namespace ToToAirline.Models.Passenger.Airline
{
    public class CreateAirlineRequest
    {
        public CreateAirlineRequest(string airlineCode, string airlineName, string airlineCounty)
        {
            AirlineCode = airlineCode;
            AirlineName = airlineName;
            AirlineCounty = airlineCounty;
        }

        public string AirlineCode { get; set; } = string.Empty;
        public string AirlineName { get; set; } = string.Empty;
        public string AirlineCounty { get; set; } = string.Empty;
    }
}