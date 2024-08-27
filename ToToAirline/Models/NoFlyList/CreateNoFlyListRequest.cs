
namespace ToToAirline.Models.NoFlyList
{
    public class CreateNoFlyListRequest
    {
        public CreateNoFlyListRequest(string activeFrom, string activeTo, Guid passengerId)
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