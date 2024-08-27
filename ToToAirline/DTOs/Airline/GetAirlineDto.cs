
namespace ToToAirline.DTOs.Airline
{
    public class GetAirlineDto
    {
        public GetAirlineDto(Guid id, string airlineCode, string airlineName, string airlineCounty)
        {
            Id = id;
            AirlineCode = airlineCode;
            AirlineName = airlineName;
            AirlineCounty = airlineCounty;
        }

        public Guid Id { get; }
        public string AirlineCode { get; } = string.Empty;
        public string AirlineName { get; } = string.Empty;
        public string AirlineCounty { get; } = string.Empty;
    }
}