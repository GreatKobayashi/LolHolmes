namespace LolHolmes.Domain.Exceptions
{
    public class AccountApiException : LolHolmesException
    {
        public AccountApiException(string? message = null) : base(ErrorCode.ApiRequestFailed, message)
        {
        }
        public AccountApiException(ErrorCode errorCode, string? message = null) : base(errorCode, message)
        {
        }
        public AccountApiException(Exception innerException, ErrorCode errorCode = ErrorCode.ApiRequestFailed, string? message = null) : base(innerException, errorCode, message)
        {
        }
    }
}
