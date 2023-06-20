using System.Threading.Tasks;

namespace Vculp.Api.Common.Broadcast
{
    public interface IBroadcaster
    {
        Task BroadcastAsync(IBroadcast broadcast);
    }
}
