using Vculp.Api.Common.Common;

namespace Vculp.Api.Application.Services.Common
{
    public class SuccessCommandResult : OperationResult, ICommandResult
    {
        public CommandResultType ResultType => CommandResultType.Success;
    }
}
