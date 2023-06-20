using System.Collections.Generic;

namespace Vculp.Api.Common.Common
{
    public interface IOperationResult
    {
        bool Success { get; }
        IReadOnlyCollection<IOperationError> Errors { get; }
    }
}
