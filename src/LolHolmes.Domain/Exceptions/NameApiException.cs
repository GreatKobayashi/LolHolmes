namespace LolHolmes.Domain.Exceptions
{
    public class NameApiException : LolHolmesException
    {
        public NameApiException(string? message = null) : base(ErrorCode.ApiRequestFailed, message)
        {
        }
        public NameApiException(ErrorCode errorCode, string? message = null) : base(errorCode, message)
        {
        }
        public NameApiException(Exception innerException, ErrorCode errorCode = ErrorCode.ApiRequestFailed, string? message = null) : base(innerException, errorCode, message)
        {
        }
    }
}
