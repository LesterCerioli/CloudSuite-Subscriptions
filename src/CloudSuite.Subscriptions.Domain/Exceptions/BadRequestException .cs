namespace CloudSuite.Subscriptions.Domain.Exceptions
{
    public abstract class BadRequestException 
    {
        protected BadRequestException(string message)
            : base("Bad Request", message)
        {
        }
        
    }
}