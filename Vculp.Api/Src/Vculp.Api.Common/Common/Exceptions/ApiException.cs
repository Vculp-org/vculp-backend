using System;
using System.Net;

namespace Vculp.Api.Common.Common.Exceptions
{
    public class ApiException : Exception
    {
        public ApiException(HttpStatusCode statusCode, string content)
        {
            if (string.IsNullOrWhiteSpace(content))
            {
                throw new ArgumentException($"{nameof(content)} cannot be null, empty or contain only whitespace",
                    nameof(content));
            }

            StatusCode = statusCode;
            Content = content;
        }

        public HttpStatusCode StatusCode { get; }

        public string Content { get; }
    }
}