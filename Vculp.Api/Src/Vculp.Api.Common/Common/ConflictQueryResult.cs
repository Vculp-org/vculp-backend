namespace Vculp.Api.Common.Common
{
    public class ConflictQueryResult : OperationResult, IQueryResult
    {
        public QueryResultType ResultType => QueryResultType.Conflict;
    }
}
