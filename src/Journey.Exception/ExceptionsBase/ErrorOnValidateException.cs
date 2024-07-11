using System.Net;

namespace Journey.Exception.ExceptionsBase
{
    public class ErrorOnValidateException : JourneyException
    {
        public ErrorOnValidateException(string message) : base(message)
        {
        }

        public override HttpStatusCode GetStatusCode()
        {
            return HttpStatusCode.BadRequest;
        }
    }
}
