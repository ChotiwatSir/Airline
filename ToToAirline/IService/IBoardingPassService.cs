using ToToAirline.DTOs.BoardingPass;

namespace ToToAirline.IService
{
    public interface IBoardingPassService
    {
        public void CreateBoardingPass(Guid BookId ,CreateBoardingPassDto create);
        public GetBoardingPassDto GetBoardingPass(Guid BookingId);
    }
}