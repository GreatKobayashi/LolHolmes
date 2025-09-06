namespace LolHolmes.Domain.Exceptions
{
    public class AccountSearchException : LolHolmesException
    {
        public AccountSearchException(ErrorCode errorCode, string? message = null) : base(errorCode, message)
        {
        }
    }
}
