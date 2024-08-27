
namespace ToToAirline.DTOs.Passenger
{
    public class CreatePassengetDto
    {
        public CreatePassengetDto(string firstName, string lastName, DateTime dateOfBirthday, string passportNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirthday = dateOfBirthday;
            PassportNumber = passportNumber;
        }

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirthday { get; set; }
        public string PassportNumber { get; set; }
    }
}