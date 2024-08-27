using ToToAirline.DTOs.Passenger;
using ToToAirline.DTOs.NoFlyList;
using ToToAirline.Entities;
using ToToAirline.IRepository;
using ToToAirline.IService;

namespace ToToAirline.Service
{
    public class NoFlyListService : INoFlyListService
    {
        private readonly IRepository<NoFlyList> _repository;

        public NoFlyListService(IRepository<NoFlyList> repository)
        {
            _repository = repository;
        }
        public void CreateNoFlyList(CreateNoFlyListDto create)
        {
            _repository.Insert(new NoFlyList(create.ActiveFrom, create.ActiveTo,create.PassengerId));
            _repository.Commit();
        }

        public GetNoFlyListDto GetNoFlyList(Guid passengerId)
        {
            var noflylist = _repository.Table.Where(g => g.Passenger.Id == passengerId)
                            .Select(g => new GetNoFlyListDto(g.Id, g.ActiveFrom, g.ActiveTo,g.Passenger.NoFlyLists
                            .Select(p => new GetPassengerDto(p.Id, p.Passenger.FirstName, p.Passenger.LastName, p.Passenger.DateOfBirthday, p.Passenger.PassportNumber))
                            .ToList())).FirstOrDefault() ?? throw new Exception("Not Found Id");

            return noflylist;
        }
    }
}