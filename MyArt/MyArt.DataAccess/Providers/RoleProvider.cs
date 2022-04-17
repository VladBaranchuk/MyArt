using Microsoft.EntityFrameworkCore;
using MyArt.DataAccess.Contracts;
using MyArt.DataAccess.Contracts.Providers;
using MyArt.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MyArt.DataAccess.Providers
{
    public class RoleProvider : BaseProvider<Role>, IRoleProvider
    {
        private readonly DbSet<Role> _roleEntities;

        public RoleProvider(IDataProvider dataProvider) : base(dataProvider)
        {
            _roleEntities = dataProvider.GetSet<Role>();
        }

        public async override Task<Role> GetItemByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _roleEntities.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }
    }
}
