using Microsoft.EntityFrameworkCore;
using MyArt.DataAccess.Contracts;
using MyArt.DataAccess.Contracts.Providers;
using MyArt.Domain.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MyArt.DataAccess.Providers
{
    public class UserProvider : BaseProvider<User>, IUserProvider
    {
        private readonly DbSet<User> _userEntities;

        public UserProvider(IDataProvider dataProvider) : base(dataProvider)
        {
            _userEntities = dataProvider.GetSet<User>();
        }
        public override async Task<User> GetItemByIdAsync(int id, CancellationToken token)
        {
            return await _userEntities.Include(x => x.RoleToUsers).ThenInclude(x => x.Role).FirstOrDefaultAsync(x => x.Id == id, token);
        }
        public async Task<User> GetItemByAliasAsync(string alias, CancellationToken token)
        {
            return await _userEntities.Include(x => x.RoleToUsers).ThenInclude(x => x.Role).FirstOrDefaultAsync(x => x.Alias == alias, token);
        }
        public async Task<User> GetItemByEmailAsync(string email, CancellationToken token)
        {
            return await _userEntities.Include(x => x.RoleToUsers).ThenInclude(x => x.Role).Where(x => x.Email == email).FirstOrDefaultAsync(token);
        }
        public async Task<byte[]> GetAvatarAsync(int userId, CancellationToken cancellationToken)
        {
            var query = await _userEntities
                .Where(x => x.Id == userId)
                .Select(x => x.Data)
                .FirstOrDefaultAsync(cancellationToken);

            return query;
        }
        public Task<bool> HasAnyByEmailAsync(string email, CancellationToken token)
        {
            return _userEntities.AnyAsync(x => x.Email == email, token);
        }
    }
}
