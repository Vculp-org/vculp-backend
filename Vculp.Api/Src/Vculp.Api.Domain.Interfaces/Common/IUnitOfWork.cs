using System.Threading.Tasks;

namespace Vculp.Api.Domain.Interfaces.Common
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync();
    }
}
