
using ToToAirline.Models.Passenger.Airline;
using ToToAirline.Models.Passenger.Airport;

namespace ToToAirline.Models.Flight
{
    public class GetFlightResponse
    {
        public GetFlightResponse(Guid id, string departureGate, string arrivingGate,Guid departingAirportId, Guid arrivingAirportId, GetAirlineResponse? getAirline, GetAirportResponse? arrivingAirport, GetAirportResponse? departingAirport)
        {
            Id = id;
            DepartureGate = departureGate;
            ArrivingGate = arrivingGate;
            DepartingAirportId = departingAirportId;
            ArrivingAirportId = arrivingAirportId;
            GetAirline = getAirline;
            ArrivingAirport = arrivingAirport;
            DepartingAirport = departingAirport;
        }

        public Guid Id { get; }
        public string DepartureGate { get; } = string.Empty;
        public string ArrivingGate { get; } = string.Empty;
        public Guid DepartingAirportId { get; }
        public Guid ArrivingAirportId { get; }
        public GetAirlineResponse? GetAirline { get; }
        public GetAirportResponse? ArrivingAirport { get; }
        public GetAirportResponse? DepartingAirport { get; }

    }
}