namespace ToToAirline.MiddleWare.Exceptions
{
    public class PresicionException:Exception
    {
        public PresicionException(string message) : base(message + "Overweight")
        {
            
        }
    }
}