using ToToAirline.DTOs.BaggageCheck;

namespace ToToAirline.IService
{
    public interface IBaggageCheckService
    {
        public GetBaggageCheckDto GetBaggageCheck(Guid BookingId, Guid PassengerId);
        public void CreateBaggageCheck(CreateBaggageCheckDto create);
        public void UpdateBaggageCheck(Guid baggageCheckId, UpdateBaggageCheckDto update);
        public void DeleteBaggageCheck(Guid baggageCheckId);
    }
}