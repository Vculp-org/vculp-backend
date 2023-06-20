using System;

namespace Vculp.Api.Common.Common
{
    public class MissingMessageContextException : Exception
    {
        public MissingMessageContextException(string keyName)
            : base($"Key {keyName} not found on message context.")
        {
            if (string.IsNullOrWhiteSpace(keyName))
            {
                throw new ArgumentException($"{nameof(keyName)} cannot be null, empty or contain only whitespace", nameof(keyName));
            }

            KeyName = keyName;
        }

        public string KeyName { get; }
    }
}
