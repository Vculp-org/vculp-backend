namespace Vculp.Api.Common.Common
{
    public class ConflictQueryResult<T> : OperationResult<T>, IQueryResult<T>
    {
        public QueryResultType ResultType => QueryResultType.Conflict;
    }
}
