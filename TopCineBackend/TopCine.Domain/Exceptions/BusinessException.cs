using System;
using System.Collections.Generic;
using System.Text;

namespace TopCine.Domain.Exceptions
{
    public class BusinessException : Exception
    {
        public BusinessException(ErrorCodes errorCode, string message) : base(message)
        {
            ErrorCode = errorCode;
        }

        public ErrorCodes ErrorCode { get; }
    }
}
