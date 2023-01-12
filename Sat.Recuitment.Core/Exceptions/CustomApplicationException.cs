using Sat.Recruitment.Core.Enums;
using System;

namespace Sat.Recruitment.Core.Exceptions
{
    public class CustomApplicationException : Exception
    {
        public ApplicationErrors ErrorCode { get; set; }

        public CustomApplicationException(string message, ApplicationErrors error)
            : base(message)
        {
            ErrorCode = error;
        }
    }
}
