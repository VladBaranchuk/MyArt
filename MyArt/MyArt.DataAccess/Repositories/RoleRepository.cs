using Microsoft.EntityFrameworkCore;
using MyArt.DataAccess.Contracts;
using MyArt.DataAccess.Contracts.Repositories;
using MyArt.Domain.Entities;
using MyArt.Domain.Enums;
using System.Threading;
using System.Threading.Tasks;

namespace MyArt.DataAccess.Repositories
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        private readonly DbSet<RoleToUser> _roleToUserEntities;
        private readonly DbSet<Role> _roleEntities;
        

        public RoleRepository(IDataProvider dataProvider) : base(dataProvider)
        {
            _roleToUserEntities = dataProvider.GetSet<RoleToUser>();
            _roleEntities = dataProvider.GetSet<Role>();
        }

        public Task AddRolesAsync(CancellationToken cancellationToken)
        {
            _roleEntities.Add(new Role() { Name = "Guest"});
            _roleEntities.Add(new Role() { Name = "User" });
            _roleEntities.Add(new Role() { Name = "Moderator" });
            return Task.CompletedTask;
        }

        public Task AddRoleToUserAsync(User user, ERole roleId, CancellationToken cancellationToken)
        {
            _roleToUserEntities.Add(new RoleToUser() { RoleId = (int)roleId, User = user });
            return Task.CompletedTask;
        }
    }
}
