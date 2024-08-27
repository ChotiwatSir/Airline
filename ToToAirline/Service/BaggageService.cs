using ToToAirline.DTOs.Passenger;
using ToToAirline.DTOs.Baggage;
using ToToAirline.DTOs.Booking;
using ToToAirline.Entities;
using ToToAirline.IRepository;
using ToToAirline.IService;

namespace ToToAirline.Service
{
    public class BaggageService : IBaggageService
    {
        private readonly IRepository<Baggage> _baggageRepository;

        public BaggageService(IRepository<Baggage> baggageRepository)
        {
            _baggageRepository = baggageRepository;
        }
        public void CreateBaggage(CreateBaggageDto create)
        {
            _baggageRepository.Insert(new Baggage(create.WeightInKg,create.BookingId));
            _baggageRepository.Commit();
        }

        public void DeleteBaggage(Guid bookingId)
        {
            var baggage = _baggageRepository.Table.Where(b => b.Booking.Id == bookingId).FirstOrDefault();
            _baggageRepository.Delete(baggage!);
            _baggageRepository.Commit();
        }

        public GetBaggageDto GetBaggage(Guid BookingId)
        {
            var baggage = _baggageRepository.Table.Where(bg => bg.Booking.Id == BookingId)
            
                                            .Select(bg => new GetBaggageDto(bg.Id, bg.WeightInKg, bg.Booking.Baggages
                                            .Select(b => new GetBookingDto(b.Booking.Id, bg.Booking.FlightId, b.Booking.Status, b.Booking.BookingPaltform, b.Booking.Passenger.Bookings
                                            .Select(p => new GetPassengerDto(p.Passenger.Id, p.Passenger.FirstName, p.Passenger.LastName, p.Passenger.DateOfBirthday, p.Passenger.PassportNumber))
                                            .ToList())).FirstOrDefault())).FirstOrDefault() ?? throw new Exception();
            return baggage;
                                                             
        }

        public void UpdateBaggage(Guid baggageId, UpdateBaggageDto update)
        {
            var baggage = _baggageRepository.Table.Where(b => b.Id == baggageId).FirstOrDefault();
            baggage!.WeightInKg = update.WeightInKg;
            baggage.BookingId = update.BookingId;
            _baggageRepository.Update(baggage);
            _baggageRepository.Commit();
        }
    }
}