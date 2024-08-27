
using ToToAirline.Models.Passenger;

namespace ToToAirline.Models.SecurityCheck
{
    public class GetSecurityCheckResponse
    {
        public GetSecurityCheckResponse(Guid id, string checkResult, string? comment, List<GetPassengerResponse>? getPassengers)
        {
            Id = id;
            CheckResult = checkResult;
            Comment = comment;
            GetPassengers = getPassengers;
        }

        public Guid Id { get;  }
        public string CheckResult { get;  } = string.Empty;
        public string? Comment { get;  }
        public List<GetPassengerResponse>? GetPassengers { get;  }
    }
}