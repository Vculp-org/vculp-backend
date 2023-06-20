using System;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.Net.Http.Headers;

namespace Vculp.Api.Common
{
    [AttributeUsage(AttributeTargets.Method)]
    public class AcceptHeaderAttribute : Attribute, IActionConstraint
    {
        public AcceptHeaderAttribute(string contentType)
        {
            if (MediaTypeHeaderValue.TryParse(contentType, out var mediaType))
            {
                AllowedMediaTypeValue = mediaType;
            }
            else
            {
                throw new ArgumentException($"{nameof(contentType)} is not a valid media type", nameof(contentType));
            }
        }

        public MediaTypeHeaderValue AllowedMediaTypeValue { get; set; }

        public int Order => 0;

        public bool Accept(ActionConstraintContext context)
        {
            var requestAccept = context.RouteContext.HttpContext.Request.Headers[HeaderNames.Accept];

            return AllowedMediaTypeValue.MediaType.Equals(requestAccept);
        }
    }
}