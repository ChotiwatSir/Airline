using ToToAirline.DTOs.Booking;

namespace ToToAirline.IService
{
    public interface IBookingService
    {
        public GetBookingDto GetBooking(Guid passengerId);
        public void CreateBooking(CreateBookingDto create);
        public void UpdateBooking(Guid bookingId, UpdateBookingDto update);
        public void DeleteBooking(Guid bookingId);
    }
}