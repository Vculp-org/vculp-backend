using System.Threading.Tasks;
using Vculp.Api.Domain.Interfaces.Common;

namespace Vculp.Api.Domain.Interfaces.User
{
    public interface IUserRepository : IRepository<Core.User.User>
    {
        Task<Domain.Core.User.User> GetByEmailAsync(string email);
        Task<Domain.Core.User.User> GetByMobileAsync(string mobile);
        Task<bool> ExistAsync(string mobile);
        Task<bool> ExistWithEmailAsync(string email);
        
    }
}