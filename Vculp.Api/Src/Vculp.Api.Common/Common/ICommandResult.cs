namespace Vculp.Api.Common.Common
{
    public interface ICommandResult : IOperationResult
    {
        CommandResultType ResultType { get; }
    }
}
