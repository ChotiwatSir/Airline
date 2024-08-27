namespace ToToAirline.Entities
{
    public class SecurityCheck
    {
        public SecurityCheck(string checkResult, string? comment, Guid passengerId)
        {
            Id = Guid.NewGuid();
            CheckResult = checkResult;
            Comment = comment;
            PassengerId = passengerId;
        }

        public Guid Id { get; set; }
        public string CheckResult { get; set; } = string.Empty;
        public string? Comment { get; set; } 
        public Guid PassengerId { get; set; }
        public Passenger Passenger { get; set; } = null!;
    }
}