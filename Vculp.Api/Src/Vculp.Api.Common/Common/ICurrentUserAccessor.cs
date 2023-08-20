using System;

namespace Vculp.Api.Common.Common
{
    public interface ICurrentUserAccessor
    {
        int? UserId { get; }
        string Name { get; }
    }
}
