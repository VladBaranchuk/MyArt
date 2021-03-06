using MyArt.Domain.Entities;
using MyArt.Domain.Enums;
using System.Threading;
using System.Threading.Tasks;

namespace MyArt.DataAccess.Contracts.Repositories
{
    public interface IRoleRepository : IRepository<Role>
    {
        Task AddRolesAsync(CancellationToken cancellationToken);
        Task AddRoleToUserAsync(User user, ERole roleId, CancellationToken cancellationToken);
    }
}
