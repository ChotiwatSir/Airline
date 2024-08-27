using ToToAirline.DTOs.Airline;
using ToToAirline.DTOs.Airport;
using ToToAirline.DTOs.Flight;
using ToToAirline.Entities;
using ToToAirline.IRepository;
using ToToAirline.IService;

namespace ToToAirline.Service
{
    public class FlightService : IFlightService
    {
        private readonly IRepository<Flight> _flightRepository;

        public FlightService(IRepository<Flight> flightRepository)
        {
            _flightRepository = flightRepository;
        }
        public void CreateFlight(CreateFlightDto create)
        {
            _flightRepository.Insert(new Flight(create.DepartureGate, create.ArrivingGate,create.AirlineId,create.DepartureAirportId,create.ArrivingAirportId));
            _flightRepository.Commit();
        }

        public void DeleteFlight(Guid flightId)
        {
            var flight = _flightRepository.Table.Where(f => f.Id == flightId).FirstOrDefault();
            _flightRepository.Delete(flight!);
            _flightRepository.Commit();
        }

        public List<GetFlightDto> GetFlights()
        {
            var flight = _flightRepository.Table.Select(f => new GetFlightDto(f.Id, f.DepartureGate, f.ArrivingGate,
                                                        new GetAirlineDto(f.Airline.Id, f.Airline.AirlineCode, f.Airline.AirlineName, f.Airline.AirlineCounty), f.DepartureAirportId, f.ArrivingAirportId,
                                                        new GetAirportDto(f.DepartingAirport.Id, f.DepartingAirport.AirportName, f.DepartingAirport.County, f.DepartingAirport.State, f.DepartingAirport.City),
                                                        new GetAirportDto(f.ArrivingAirport.Id, f.ArrivingAirport.AirportName, f.ArrivingAirport.County, f.ArrivingAirport.State, f.ArrivingAirport.City))).ToList() ?? throw new Exception();
                                                
            return flight;

        }

        public void UpdateFlight(Guid flightId, UpdateFlightDto update)
        {
            var flight = _flightRepository.Table.Where(f => f.Id == flightId).FirstOrDefault();
            flight!.DepartureGate = update.DepartureGate;
            flight.ArrivingGate = update.ArrivingGate;
            flight.AirlineId = update.AirlineId;
            flight.DepartureAirportId = update.DepartureAirportId;
            flight.ArrivingAirportId = update.ArrivingAirportId;

            _flightRepository.Update(flight);
            _flightRepository.Commit();
        }
    }
}