using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LolHolmes.Domain.Exceptions
{
    public class NameSearchException : LolHolmesException
    {
        public NameSearchException(ErrorCode errorCode, string? message = null) : base(errorCode, message)
        {
        }
    }
}
