namespace Vculp.Api.Common.Common
{
    public class UnprocessableEntityQueryResult : OperationResult, IQueryResult
    {
        public QueryResultType ResultType => QueryResultType.UnprocessableEntity;
    }
}
