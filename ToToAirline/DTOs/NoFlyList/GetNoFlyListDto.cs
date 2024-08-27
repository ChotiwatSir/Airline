using ToToAirline.DTOs.Passenger;

namespace ToToAirline.DTOs.NoFlyList
{
    public class GetNoFlyListDto
    {
        public GetNoFlyListDto(Guid id, string activeFrom, string activeTo,List<GetPassengerDto> passenger)
        {
            Id = id;
            ActiveFrom = activeFrom;
            ActiveTo = activeTo;
            Passenger = passenger;

        }

        public Guid Id { get; set; }
        public string ActiveFrom { get; set; } = string.Empty;
        public string ActiveTo { get; set; } = string.Empty;
        public List<GetPassengerDto> Passenger { get; set; }
    }
}