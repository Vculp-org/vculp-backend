using Vculp.Api.Common.Common;

namespace Vculp.Api.Application.Services.Common
{
    public class UnprocessableEntityCommandResult : OperationResult, ICommandResult
    {
        public CommandResultType ResultType => CommandResultType.UnprocessableEntity;
    }
}
