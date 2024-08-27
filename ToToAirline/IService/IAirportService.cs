using ToToAirline.DTOs.Airport;

namespace ToToAirline.IService
{
    public interface IAirportService
    {
        public List<GetAirportDto> GetAirport();
        public void CreateAirport(CreateAirportDto create);
    }
}