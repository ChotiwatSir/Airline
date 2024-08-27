using ToToAirline.DTOs.Airline;

namespace ToToAirline.IService
{
    public interface IAirlineService
    {
        public List<GetAirlineDto> GetAirline();
        public void CreateAirline(CreateAirlineDto create);
    }
}