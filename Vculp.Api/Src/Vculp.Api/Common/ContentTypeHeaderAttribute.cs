using System;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.Net.Http.Headers;

namespace Vculp.Api.Common
{
    [AttributeUsage(AttributeTargets.Method)]
    public class ContentTypeHeaderAttribute : Attribute, IActionConstraint
    {
        public ContentTypeHeaderAttribute(string contentType)
        {
            if (MediaTypeHeaderValue.TryParse(contentType, out var parsedContentType))
            {
                AllowedContentTypeValue = parsedContentType;
            }
            else
            {
                throw new ArgumentException($"{nameof(parsedContentType)} is not a valid media type", nameof(parsedContentType));
            }
        }

        public MediaTypeHeaderValue AllowedContentTypeValue { get; set; }

        public int Order => 0;

        public bool Accept(ActionConstraintContext context)
        {
            var requestAccept = context.RouteContext.HttpContext.Request.Headers[HeaderNames.ContentType];

            if (requestAccept.Count == 0)
                return false;

            return AllowedContentTypeValue.MediaType.Equals(requestAccept);
        }
    }
}