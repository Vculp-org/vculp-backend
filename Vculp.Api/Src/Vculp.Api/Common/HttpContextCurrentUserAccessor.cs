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
                var customerId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.CustomerId);
                var name = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name);
                var userId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Subject);
                var driverCode = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.DriverCode);
                var haulierName = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.HaulierName);
                var vetId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.VetId);
                var salesRepId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.SalesRepId);

                CustomerId = customerId != null
                    ? Guid.Parse(customerId.Value)
                    : (Guid?)null;
                UserId = userId != null
                    ? int.Parse(userId.Value)
                    : (int?)null;
                Name = name?.Value;
                DriverCode = driverCode?.Value;
                HaulierName = haulierName?.Value;
                VetId = vetId != null
                    ? Guid.Parse(vetId.Value)
                    : (Guid?)null;
                SalesRepId = salesRepId != null
                    ? Guid.Parse(salesRepId.Value)
                    : (Guid?)null;
            }
        }

        public Guid? CustomerId { get; }
        public int? UserId { get; }
        public string Name { get; }
        public string HaulierName { get; }
        public string DriverCode { get; }
        public Guid? VetId { get; }
        public Guid? SalesRepId { get; }
    }
}
