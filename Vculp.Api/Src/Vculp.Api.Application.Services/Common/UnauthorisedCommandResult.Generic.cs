using Vculp.Api.Common.Common;

namespace Vculp.Api.Application.Services.Common;

public class UnauthorisedCommandResult<T> : OperationResult<T>, ICommandResult<T>
{
    public CommandResultType ResultType { get; } = CommandResultType.Unauthorised;
}