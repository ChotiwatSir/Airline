
namespace ToToAirline.DTOs.Airline
{
    public class CreateAirlineDto
    {
        public CreateAirlineDto(string airlineCode, string airlineName, string airlineCounty)
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