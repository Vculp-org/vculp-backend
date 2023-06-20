namespace Vculp.Api.Common.Common
{
    public class SuccessQueryResult : OperationResult, IQueryResult
    {
        public QueryResultType ResultType => QueryResultType.Success;
    }
}
