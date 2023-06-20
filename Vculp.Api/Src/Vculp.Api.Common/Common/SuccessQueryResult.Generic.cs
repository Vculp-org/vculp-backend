namespace Vculp.Api.Common.Common
{
    public class SuccessQueryResult<T> : OperationResult<T>, IQueryResult<T>
    {
        public QueryResultType ResultType => QueryResultType.Success;
    }
}
