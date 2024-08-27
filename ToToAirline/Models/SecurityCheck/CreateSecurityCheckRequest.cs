
namespace ToToAirline.Models.SecurityCheck
{
    public class CreateSecurityCheckRequest
    {
        public CreateSecurityCheckRequest(string checkResult, string? comment, Guid passengerId)
        {
            CheckResult = checkResult;
            Comment = comment;
            PassengerId = passengerId;
        }

        public string CheckResult { get; set; } = string.Empty;
        public string? Comment { get; set; }
        public Guid PassengerId { get; set; }
    }
}