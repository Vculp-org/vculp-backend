namespace Vculp.Api.Common.Common
{
    public interface IOperationResult<out T> : IOperationResult
    {
        T Result { get; }
    }
}
