using Microsoft.EntityFrameworkCore;
using MyArt.DataAccess.Contracts;
using MyArt.DataAccess.Contracts.Providers;
using MyArt.Domain.Entities;
using MyArt.Domain.Enums;
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

        public Task<int> GetPaintingsCountAsync(int id, CancellationToken token)
        {
            return _userEntities
                .Where(x => x.Id == id)
                .Select(x => x.Arts.Where(x => x.Type == EType.Picture))
                .CountAsync(token);
        }
        public Task<int> GetPhotosCountAsync(int id, CancellationToken token)
        {
            return _userEntities
                .Where(x => x.Id == id)
                .Select(x => x.Arts.Where(x => x.Type == EType.Photo))
                .CountAsync(token);
        }
        public Task<int> GetSculpturesCountAsync(int id, CancellationToken token)
        {
            return _userEntities
                .Where(x => x.Id == id)
                .Select(x => x.Arts.Where(x => x.Type == EType.Sculpture))
                .CountAsync(token);
        }
        public override Task<User> GetItemByIdAsync(int id, CancellationToken token)
        {
            return _userEntities.Include(x => x.RoleToUsers).ThenInclude(x => x.Role).FirstOrDefaultAsync(x => x.Id == id);
        }
        public Task<User> GetItemByEmailAsync(string email, CancellationToken token)
        {
            return _userEntities.Include(x => x.RoleToUsers).ThenInclude(x => x.Role).FirstOrDefaultAsync(x => x.Email == email);
        }
        public Task<bool> HasAnyByEmailAsync(string email, CancellationToken token)
        {
            return _userEntities.AnyAsync(x => x.Email == email, token);
        }
    }
}
