
using MyArt.BusinessLogic.Contracts;
using MyArt.DataAccess.Contracts;
using MyArt.DataAccess.Contracts.Repositories;

namespace MyArt.BusinessLogic.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IDataContext _db;

        public RoleService(
            IDataContext context,
            IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
            _db = context;
        }
        public async Task AddRolesAsync(CancellationToken cancellationToken)
        {
            await _roleRepository.AddRolesAsync(cancellationToken);
            await _db.SaveChangesAsync(cancellationToken);
        }
    }
}
