namespace ToToAirline.MiddleWare.Exceptions
{
    public class NotFoundException:Exception
    {
        public NotFoundException(string message) : base(message + "Not Found Id")
        {
            
        }
    }
}