using Vculp.Api.Common.Common;

namespace Vculp.Api.Application.Services.Common
{
    public class NotFoundCommandResult : OperationResult, ICommandResult
    {
        public CommandResultType ResultType => CommandResultType.NotFound;
    }
}
