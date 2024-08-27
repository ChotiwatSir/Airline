
namespace ToToAirline.Models.Flight
{
    public class UpdateFlightRequest
    {
        public UpdateFlightRequest(string departureGate, string arrivingGate, Guid airlineId, Guid departureAirportId, Guid arrivingAirportId)
        {
            DepartureGate = departureGate;
            ArrivingGate = arrivingGate;
            AirlineId = airlineId;
            DepartureAirportId = departureAirportId;
            ArrivingAirportId = arrivingAirportId;
        }

        public string DepartureGate { get; set; } = string.Empty;
        public string ArrivingGate { get; set; } = string.Empty;
        public Guid AirlineId { get; set; }
        public Guid DepartureAirportId { get; set; }
        public Guid ArrivingAirportId { get; set; }
    }
}