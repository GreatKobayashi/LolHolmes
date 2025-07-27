namespace LolHolmes.Domain.Exceptions
{
    public class LolHolmesException : Exception
    {
        protected LolHolmesException(ErrorCode errorCode, string? message) : base(message)
        {
            ErrorCode = errorCode;
        }

        protected LolHolmesException(Exception innerException, ErrorCode errorCode, string? message) : base(message, innerException)
        {
            ErrorCode = errorCode;
        }

        public ErrorCode ErrorCode { get; }
    }

    public enum ErrorCode
    {
        Unexpected,
        ApiRequestFailed,
        NameSearchLimit,
        InvalidRiotId,
        InvalidTagLine,
        AccountNotFound,
        OverRequestLimit
    }
}
