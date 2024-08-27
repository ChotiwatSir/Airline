using ToToAirline.DTOs.Passenger;

namespace ToToAirline.DTOs.SecurityCheck
{
    public class GetSecurityCheckDto
    {
        public GetSecurityCheckDto(Guid id, string checkResult, string? comment, List<GetPassengerDto>? getPassengers)
        {
            Id = id;
            CheckResult = checkResult;
            Comment = comment;
            GetPassengers = getPassengers;
        }

        public Guid Id { get; set; }
        public string CheckResult { get; set; } = string.Empty;
        public string? Comment { get; set; }
        public List<GetPassengerDto>? GetPassengers{ get; set; }
    }
}