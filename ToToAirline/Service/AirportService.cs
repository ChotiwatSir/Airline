using ToToAirline.DTOs.Airport;
using ToToAirline.Entities;
using ToToAirline.IRepository;
using ToToAirline.IService;

namespace ToToAirline.Service
{
    public class AirportService : IAirportService
    {
        private readonly IRepository<Airport> _repository;

        public AirportService(IRepository<Airport> repository)
        {
            _repository = repository;
        }
        public void CreateAirport(CreateAirportDto create)
        {
            _repository.Insert(new Airport(create.AirportName, create.County, create.State, create.City));
            _repository.Commit();
        }

        public List<GetAirportDto> GetAirport()
        {
            var airport = _repository.Table.Select(ap => new GetAirportDto(ap.Id, ap.AirportName, ap.County, ap.State, ap.City)).ToList();
            return airport;
        }
    }
}