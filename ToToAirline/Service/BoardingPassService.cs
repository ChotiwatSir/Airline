using ToToAirline.DTOs.Passenger;
using ToToAirline.DTOs.BoardingPass;
using ToToAirline.DTOs.Booking;
using ToToAirline.Entities;
using ToToAirline.IRepository;
using ToToAirline.IService;

namespace ToToAirline.Service
{
    public class BoardingPassService : IBoardingPassService
    {
        private readonly IRepository<BoardingPass> _boardingPassPepository;
        private readonly IRepository<Booking> _bookingRepository;

        public BoardingPassService(IRepository<BoardingPass> boardingPassPepository,
                                    IRepository<Booking> bookingRepository)
        {
            _boardingPassPepository = boardingPassPepository;
            _bookingRepository = bookingRepository;
        }
        public void CreateBoardingPass(Guid BookId, CreateBoardingPassDto create)
        {
            var bookingId = _bookingRepository.Table
                                                .Where(b => b.Id == BookId)
                                                .Select(b =>  b.Id)
                                                .FirstOrDefault();


            _boardingPassPepository.Insert(new BoardingPass(create.QRCode, bookingId));
            _boardingPassPepository.Commit();
        }

        public GetBoardingPassDto GetBoardingPass(Guid BookingId)
        {
            var boarding = _boardingPassPepository.Table.Where(b => b.Booking.Id == BookingId)
                                            .Select(bp => new GetBoardingPassDto(bp.Id, bp.QRCode, bp.Booking.BoardingPasses
                                            .Select(bk => new GetBookingDto(bk.Booking.Id, bk.Booking.FlightId, bk.Booking.Status, bk.Booking.BookingPaltform, bk.Booking.Passenger.Bookings
                                            .Select(p => new GetPassengerDto(p.Passenger.Id, p.Passenger.FirstName, p.Passenger.LastName, p.Passenger.DateOfBirthday, p.Passenger.PassportNumber))
                                            .ToList())).FirstOrDefault())).FirstOrDefault() ?? throw new Exception("NOT FOUND Id");
            return boarding;





        }
    }
}