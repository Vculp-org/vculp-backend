using System;

namespace Vculp.Api.Domain.Core.SharedKernel.Interfaces
{
    public interface IUpdateAuditable
    {
        DateTime LastUpdated { get; }
        int? LastUpdatedByUserId { get; }
        string LastUpdatedByUserName { get; }
    }
}
