namespace LolHolmes.Domain.Exceptions
{
    public class NameSearchException : LolHolmesException
    {
        public NameSearchException(ErrorCode errorCode, string? message = null) : base(errorCode, message)
        {
        }
    }
}
