namespace Vculp.Api.Common.Common
{
    public class UnprocessableEntityQueryResult<T> : OperationResult<T>, IQueryResult<T>
    {
        public QueryResultType ResultType => QueryResultType.UnprocessableEntity;
    }
}
