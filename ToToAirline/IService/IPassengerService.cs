using ToToAirline.DTOs.Passenger;

namespace ToToAirline.IService
{
    public interface IPassengerService
    {
        public List<GetPassengerDto> GetPassengers();
        public void CreatePassenger(CreatePassengetDto create);
        public void UpdatePassenger(Guid passengerId, UpdatePassengerDto update);
        public void DeletePassenger(Guid passengerId);
    }
}