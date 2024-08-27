namespace ToToAirline.Entities
{
    public class Passenger
    {
        public Passenger( string firstName, string lastName, DateTime dateOfBirthday, string passportNumber)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            DateOfBirthday = dateOfBirthday;
            PassportNumber = passportNumber;
            Create = DateTime.UtcNow;
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirthday { get; set; }
        public string PassportNumber { get; set; } = string.Empty;
        public DateTime Create { get; set; }
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
        public ICollection<NoFlyList> NoFlyLists { get; set; } = new List<NoFlyList>();
        public ICollection<SecurityCheck> SecurityChecks { get; set; } = new List<SecurityCheck>();
        public BaggageCheck BaggageCheck { get; set; } = null!;
    }
}