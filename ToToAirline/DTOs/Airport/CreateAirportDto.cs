
namespace ToToAirline.DTOs.Airport
{
    public class CreateAirportDto
    {
        public CreateAirportDto(string airportName, string county, string state, string city)
        {
            AirportName = airportName;
            County = county;
            State = state;
            City = city;
        }

        public string AirportName { get; set; } = string.Empty;
        public string County { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;

    }
}