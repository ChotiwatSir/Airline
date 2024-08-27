using ToToAirline.DTOs.Baggage;

namespace ToToAirline.IService
{
    public interface IBaggageService
    {
        public GetBaggageDto GetBaggage(Guid bookingId);
        public void CreateBaggage(CreateBaggageDto create);
        public void UpdateBaggage(Guid baggageId, UpdateBaggageDto update);
        public void DeleteBaggage(Guid bookingId);
    }
}