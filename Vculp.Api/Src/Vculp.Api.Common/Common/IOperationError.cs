namespace Vculp.Api.Common.Common
{
    public interface IOperationError
    {
        string ErrorKey { get; }
        string ErrorMessage { get; }
    }
}
