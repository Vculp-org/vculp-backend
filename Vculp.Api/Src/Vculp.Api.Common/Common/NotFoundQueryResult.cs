namespace Vculp.Api.Common.Common
{
    public class NotFoundQueryResult : OperationResult, IQueryResult
    {
        public QueryResultType ResultType => QueryResultType.NotFound;
    }
}
