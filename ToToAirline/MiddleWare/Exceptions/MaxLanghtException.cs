namespace ToToAirline.MiddleWare.Exceptions
{
    public class MaxLanghtException:Exception
    {
        public MaxLanghtException(string message) : base(message + "Out Of Langht")
        {
            
        }
    }
}