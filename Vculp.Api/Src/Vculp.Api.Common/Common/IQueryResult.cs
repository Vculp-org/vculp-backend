namespace Vculp.Api.Common.Common
{
    public interface IQueryResult : IOperationResult
    {
        QueryResultType ResultType { get; }
    }
}
