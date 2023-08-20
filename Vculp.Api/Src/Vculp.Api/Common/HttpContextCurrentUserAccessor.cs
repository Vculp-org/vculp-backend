using System;
using Microsoft.AspNetCore.Http;
using Vculp.Api.Common.Common;

namespace Vculp.Api.Common
{
    public class HttpContextCurrentUserAccessor : ICurrentUserAccessor
    {
        public HttpContextCurrentUserAccessor(IHttpContextAccessor httpContextAccessor)
        {
            if (httpContextAccessor == null) { throw new ArgumentNullException(nameof(httpContextAccessor)); }

            if (httpContextAccessor.HttpContext != null)
            {
                var name = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name);
                var userId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Subject);
                
                UserId = userId != null
                    ? int.Parse(userId.Value)
                    : (int?)null;
                Name = name?.Value;
            }
        }
        
        public int? UserId { get; }
        public string Name { get; }
    }
}
