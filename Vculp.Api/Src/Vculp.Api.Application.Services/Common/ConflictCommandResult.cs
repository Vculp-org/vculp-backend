using Vculp.Api.Common.Common;

namespace Vculp.Api.Application.Services.Common
{
    public class ConflictCommandResult : OperationResult, ICommandResult
    {
        public CommandResultType ResultType => CommandResultType.Conflict;
    }
}
