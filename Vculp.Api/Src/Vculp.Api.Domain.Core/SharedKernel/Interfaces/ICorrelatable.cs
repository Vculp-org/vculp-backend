namespace Vculp.Api.Domain.Core.SharedKernel.Interfaces
{
    public interface ICorrelatable
    {
        string CorrelationId { get; }
    }
}
