using ToToAirline.DTOs.Passenger;
using ToToAirline.DTOs.Airline;
using ToToAirline.DTOs.Airport;
using ToToAirline.DTOs.Booking;
using ToToAirline.DTOs.Flight;
using ToToAirline.DTOs.FlightManiFest;
using ToToAirline.Entities;
using ToToAirline.IRepository;
using ToToAirline.IService;

namespace ToToAirline.Service
{
    public class FlightManiFestService : IFlightManiFestService
    {
        private readonly IRepository<FlightManifest> _flightManifestRepository;

        public FlightManiFestService(IRepository<FlightManifest> FlightManifestRepository)
        {
            _flightManifestRepository = FlightManifestRepository;
        }

        public void CreateFlightManifest(CreateFlightManifestDto create)
        {
            _flightManifestRepository.Insert(new FlightManifest(create.BookingId,create.FlightId));
            _flightManifestRepository.Commit();
        }

        public GetFlightManiFestDto GetFlightManiFest(Guid bookingId, Guid flightId)
        {
            var flightmanifest = _flightManifestRepository.Table.Where(mn => mn.Booking.Id == bookingId)
                                            .Where(mn => mn.Flight.Id == flightId).Select(mn => new GetFlightManiFestDto(mn.Id, mn.BookingId, mn.FlightId,
                                            new GetBookingDto(mn.Booking.Id, mn.Booking.FlightId, mn.Booking.Status, mn.Booking.BookingPaltform, mn.Booking.Passenger.Bookings
                                            .Select(p => new GetPassengerDto(p.Passenger.Id, p.Passenger.FirstName, p.Passenger.LastName, p.Passenger.DateOfBirthday, p.Passenger.PassportNumber)).ToList()),
                                            new GetFlightDto(mn.Flight.Id, mn.Flight.DepartureGate, mn.Flight.ArrivingGate,
                                            new GetAirlineDto(mn.Flight.Airline.Id, mn.Flight.Airline.AirlineCode, mn.Flight.Airline.AirlineName, mn.Flight.Airline.AirlineCounty), mn.Flight.DepartureAirportId, mn.Flight.ArrivingAirportId,
                                            new GetAirportDto(mn.Flight.DepartingAirport.Id, mn.Flight.DepartingAirport.AirportName, mn.Flight.DepartingAirport.County, mn.Flight.DepartingAirport.State, mn.Flight.DepartingAirport.City),
                                            new GetAirportDto(mn.Flight.ArrivingAirport.Id, mn.Flight.ArrivingAirport.AirportName, mn.Flight.ArrivingAirport.County, mn.Flight.ArrivingAirport.State, mn.Flight.ArrivingAirport.City))))
                                            .FirstOrDefault()?? throw new Exception("Not Found Id");



            return flightmanifest;
        }

    }
}