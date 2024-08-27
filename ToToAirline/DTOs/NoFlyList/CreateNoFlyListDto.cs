
namespace ToToAirline.DTOs.NoFlyList
{
    public class CreateNoFlyListDto
    {
        public CreateNoFlyListDto(string activeFrom, string activeTo, Guid passengerId)
        {
            ActiveFrom = activeFrom;
            ActiveTo = activeTo;
            PassengerId = passengerId;
        }

        public string ActiveFrom { get; set; } = string.Empty;
        public string ActiveTo { get; set; } = string.Empty;
        public Guid PassengerId { get; set; }
    }
}