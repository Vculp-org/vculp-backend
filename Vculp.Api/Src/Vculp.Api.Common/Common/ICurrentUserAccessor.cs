using System;

namespace Vculp.Api.Common.Common
{
    public interface ICurrentUserAccessor
    {
        Guid? CustomerId { get; }
        int? UserId { get; }
        string Name { get; }
        string HaulierName { get; }
        string DriverCode { get; }
        Guid? VetId { get; }
        Guid? SalesRepId { get; }
    }
}
