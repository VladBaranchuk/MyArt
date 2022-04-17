using Microsoft.EntityFrameworkCore;
using MyArt.DataAccess.Contracts;
using MyArt.DataAccess.Contracts.Repositories;
using MyArt.Domain.Entities;
using MyArt.Domain.Enums;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MyArt.DataAccess.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly IRoleRepository _roleRepository;

        public UserRepository(IRoleRepository roleRepository, IDataProvider dataProvider) : base(dataProvider)
        {
            _roleRepository = roleRepository;
        }

        public override Task CreateAsync(User user, CancellationToken CancellationToken)
        {
            ArgumentNullException.ThrowIfNull(user, nameof(user));

            base.CreateAsync(user, CancellationToken);

            _roleRepository.AddRoleToUserAsync(user, ERole.User, CancellationToken);

            return base.CreateAsync(user, CancellationToken);
        }
    }
}
