using Vculp.Api.Common.Common;

namespace Vculp.Api.Application.Services.Common;

public class UnauthorisedCommandResult: OperationResult, ICommandResult
{
    public CommandResultType ResultType { get; } = CommandResultType.Unauthorised;
}