using System;

namespace Vculp.Api.Common.Common
{
    public class OperationError : IOperationError
    {
        public OperationError(string errorKey, string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(errorKey))
            {
                throw new ArgumentException($"{nameof(errorKey)} is null, empty or contains only whitespace", nameof(errorKey));
            }

            if (string.IsNullOrWhiteSpace(errorMessage))
            {
                throw new ArgumentException($"{nameof(errorMessage)} is null, empty or contains only whitespace", nameof(errorMessage));
            }

            ErrorKey = errorKey;
            ErrorMessage = errorMessage;
        }

        public string ErrorKey { get; }

        public string ErrorMessage { get; }
    }
}
