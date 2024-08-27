
namespace ToToAirline.Models.Passenger
{
    public class GetPassengerResponse
    {

        public Guid Id { get; }
        public string FirstName { get; } = string.Empty;
        public string LastName { get; } = string.Empty;
        public DateTime DateOfBirthday { get; }
        public string PassportNumber { get; }
        public GetPassengerResponse(Guid id, string firstName, string lastName, DateTime dateOfBirthday, string passportNumber)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirthday = dateOfBirthday;
            PassportNumber = passportNumber;
        }
    }
}