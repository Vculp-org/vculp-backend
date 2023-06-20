using System;

namespace Vculp.Api.Domain.Core.SharedKernel.Interfaces
{
    public interface IOrderable
    {
        Guid Id { get; }
        int PrintOrder { get; }
        void SetPrintOrder(int order);
    }
}
