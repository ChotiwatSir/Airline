using ToToAirline.DTOs.Passenger;
using ToToAirline.DTOs.BaggageCheck;
using ToToAirline.DTOs.Booking;
using ToToAirline.Entities;
using ToToAirline.IRepository;
using ToToAirline.IService;

namespace ToToAirline.Service
{
    public class BaggageCheckService : IBaggageCheckService
    {
        private readonly IRepository<BaggageCheck> _baggageCheckRepository;

        public BaggageCheckService(IRepository<BaggageCheck> BaggageCheckRepository)
        {
            _baggageCheckRepository = BaggageCheckRepository;
        }
        public void CreateBaggageCheck(CreateBaggageCheckDto create)
        {
            _baggageCheckRepository.Insert(new BaggageCheck(create.CheckResult,create.BookingId,create.PassengerId));
            _baggageCheckRepository.Commit();
        }

        public void DeleteBaggageCheck(Guid baggageCheckId)
        {
            var baggageCheckk = _baggageCheckRepository.Table.Where(bc => bc.Id == baggageCheckId).FirstOrDefault()??throw new Exception("Not Found Id");
            _baggageCheckRepository.Delete(baggageCheckk);
            _baggageCheckRepository.Commit();
        }

        public GetBaggageCheckDto GetBaggageCheck(Guid BookingId, Guid PassengerId)
        {
            var baggagecheck = _baggageCheckRepository.Table.Where(bc => bc.Booking.Id == BookingId)
                                         .Where(bc => bc.Passenger.Id == PassengerId)
                                         .Select(bg => new GetBaggageCheckDto(bg.Id, bg.CheckResult, bg.Booking.BaggageChecks
                                         .Select(b => new GetBookingDto(b.Booking.Id, b.Booking.FlightId, bg.Booking.Status, b.Booking.BookingPaltform, b.Booking.Passenger.Bookings
                                         .Select(p => new GetPassengerDto(p.Passenger.Id, p.Passenger.FirstName, p.Passenger.LastName, p.Passenger.DateOfBirthday, p.Passenger.PassportNumber))
                                         .ToList())).FirstOrDefault())).FirstOrDefault() ?? throw new Exception("NN");
            return baggagecheck;

        }

        public void UpdateBaggageCheck(Guid baggageCheckId, UpdateBaggageCheckDto update)
        {
            var baagageCheck = _baggageCheckRepository.Table.Where(bc => bc.Id == baggageCheckId).FirstOrDefault() ?? throw new Exception("Not Found Id");
            baagageCheck.CheckResult = update.CheckResult;
            baagageCheck.BookingId = update.BookingId;
            baagageCheck.PassengerId = update.PassengerId;
            _baggageCheckRepository.Update(baagageCheck);
            _baggageCheckRepository.Commit();
        }
    }
}