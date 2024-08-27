
namespace ToToAirline.Models.NoFlyList
{
    public class GetNoFlyListResponse
    {
        public GetNoFlyListResponse(Guid id, string activeFrom, string activeTo)
        {
            Id = id;
            ActiveFrom = activeFrom;
            ActiveTo = activeTo;
        }

        public Guid Id { get; }
        public string ActiveFrom { get;  } = string.Empty;
        public string ActiveTo { get;  } = string.Empty;
    }
}