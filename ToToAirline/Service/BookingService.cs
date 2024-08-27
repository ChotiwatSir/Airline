using ToToAirline.DTOs.Passenger;
using ToToAirline.DTOs.Booking;
using ToToAirline.Entities;
using ToToAirline.IRepository;
using ToToAirline.IService;

namespace ToToAirline.Service
{
    public class BookingService : IBookingService
    {
        private readonly IRepository<Booking> _repository;

        public BookingService(IRepository<Booking> repository)
        {
            _repository = repository;
        }
        public void CreateBooking(CreateBookingDto create)
        {
            _repository.Insert(new Booking(create.FlightId, create.Status, create.BookingPaltform,create.PassengerId));
            _repository.Commit();
        }

        public void DeleteBooking(Guid bookingId)
        {
            var booking = _repository.Table.Where(b => b.Id == bookingId).FirstOrDefault()
            ?? throw new Exception("Not Found Id") ;
            _repository.Delete(booking);
            _repository.Commit();
        }

        public GetBookingDto GetBooking(Guid PassengerId)
        {
            var booking = _repository.Table.Where(b => b.Passenger.Id == PassengerId).Select(b => new GetBookingDto(b.Id, b.FlightId, b.Status, b.BookingPaltform, b.Passenger.Bookings
                                                            .Select(p => new GetPassengerDto(p.Passenger.Id, p.Passenger.FirstName, p.Passenger.LastName, p.Passenger.DateOfBirthday, p.Passenger.PassportNumber))
                                                            .ToList())).FirstOrDefault()?? throw new Exception("NotFound Id"+ PassengerId);
            return booking;
        }

        public void UpdateBooking(Guid bookingId, UpdateBookingDto update)
        {
            var booking = _repository.Table.Where(b => b.PassengerId == bookingId).FirstOrDefault()??throw new Exception("Not Found Id");
            booking.FlightId = update.FlightId;
            booking.Status = update.Status;
            booking.BookingPaltform = update.BookingPaltform;
            booking.PassengerId = update.PassengerId;
            _repository.Commit();

        }
    }
}