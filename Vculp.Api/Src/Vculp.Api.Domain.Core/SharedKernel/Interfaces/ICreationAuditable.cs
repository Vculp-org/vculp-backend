using System;

namespace Vculp.Api.Domain.Core.SharedKernel.Interfaces
{
    public interface ICreationAuditable
    {
        DateTime CreationTime { get; }
        int? CreatedByUserId { get; }
        string CreatedByUserName { get; }
    }
}
