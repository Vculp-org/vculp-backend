using Vculp.Api.Common.Common;

namespace Vculp.Api.Application.Services.Common
{
    public class UnprocessableEntityCommandResult<T> : OperationResult<T>, ICommandResult<T>
    {
        public CommandResultType ResultType => CommandResultType.UnprocessableEntity;
    }
}
