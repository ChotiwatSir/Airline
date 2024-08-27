
using ToToAirline.DTOs.Airline;
using ToToAirline.DTOs.Airport;

namespace ToToAirline.DTOs.Flight
{
    public class GetFlightDto
    {
        public GetFlightDto(Guid id, string departureGate, string arrivingGate,GetAirlineDto? getAirline, Guid departingAirportId, Guid arrivingAirportId, GetAirportDto departingAirport, GetAirportDto arrivingAirport)
        {
            Id = id;
            DepartureGate = departureGate;
            ArrivingGate = arrivingGate;
            GetAirline = getAirline;
            DepartingAirportId = departingAirportId;
            ArrivingAirportId = arrivingAirportId;
            DepartingAirport = departingAirport;
            ArrivingAirport = arrivingAirport;
        }

        public Guid Id { get; }
        public string DepartureGate { get; } = string.Empty;
        public string ArrivingGate { get; } = string.Empty;
        public GetAirlineDto? GetAirline { get; }
        public Guid DepartingAirportId { get; }
        public Guid ArrivingAirportId { get; }
        public GetAirportDto DepartingAirport { get; }
        public GetAirportDto ArrivingAirport { get; }



    }
}