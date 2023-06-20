using System.Collections.Generic;
using System.Threading.Tasks;
using Vculp.Api.Shared.Abstractions.Cqrs;


namespace Vculp.Api.Common.CommandBus
{
    public interface ICommandBus
    {
        Task SendAsync(ICommand command);
        Task SendAsync(IEnumerable<ICommand> commands);
    }
}
