namespace ToToAirline.Entities
{
    public class NoFlyList
    {
        public NoFlyList(string activeFrom, string activeTo, Guid passengerId)
        {
            Id = Guid.NewGuid();
            ActiveFrom = activeFrom;
            ActiveTo = activeTo;
            PassengerId = passengerId;
            Create = DateTime.UtcNow;
        }

        public Guid Id { get; set; }
        public string ActiveFrom { get; set; } = string.Empty;
        public string ActiveTo { get; set; } = string.Empty;
        public DateTime Create { get; set; }
        public Guid PassengerId { get; set; }
        public Passenger Passenger { get; set; } = null!;
    }
}