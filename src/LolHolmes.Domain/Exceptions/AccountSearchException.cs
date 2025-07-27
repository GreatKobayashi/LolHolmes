using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LolHolmes.Domain.Exceptions
{
    public class AccountSearchException : LolHolmesException
    {
        public AccountSearchException(ErrorCode errorCode, string? message = null) : base(errorCode, message)
        {
        }
    }
}
