using Microsoft.EntityFrameworkCore;
using MyArt.DataAccess.Contracts;
using MyArt.DataAccess.Contracts.Providers;
using MyArt.Domain.Entities;
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

        public async override Task<User> GetItemByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _userEntities.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }
    }
}
