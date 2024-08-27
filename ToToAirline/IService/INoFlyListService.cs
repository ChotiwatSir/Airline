using ToToAirline.DTOs.NoFlyList;

namespace ToToAirline.IService
{
    public interface INoFlyListService
    {
        public GetNoFlyListDto GetNoFlyList(Guid passengerId);
        public void CreateNoFlyList(CreateNoFlyListDto create);
    }
}