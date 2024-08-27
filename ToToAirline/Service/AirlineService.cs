
using ToToAirline.DTOs.Airline;
using ToToAirline.Entities;
using ToToAirline.IRepository;
using ToToAirline.IService;

namespace ToToAirline.Service
{
    public class AirlineService : IAirlineService
    {
        private readonly IRepository<Airline> _repository;

        public AirlineService(IRepository<Airline> repository)
        {
            _repository = repository;
        }
        public void CreateAirline(CreateAirlineDto create)
        {
            _repository.Insert(new Airline(create.AirlineCode, create.AirlineName, create.AirlineCounty));
            _repository.Commit();
        }

        public List<GetAirlineDto> GetAirline()
        {
            var airline = _repository.Table.Select(a => new GetAirlineDto(a.Id, a.AirlineCode, a.AirlineName, a.AirlineCounty)).ToList();
            return airline;
        }
    }
}