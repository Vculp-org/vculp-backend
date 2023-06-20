namespace Vculp.Api.Common.Common
{
    public class NotFoundQueryResult<T> : OperationResult<T>, IQueryResult<T>
    {
        public QueryResultType ResultType => QueryResultType.NotFound;
    }
}
