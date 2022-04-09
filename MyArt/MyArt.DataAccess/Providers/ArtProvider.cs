using Microsoft.EntityFrameworkCore;
using MyArt.DataAccess.Contracts;
using MyArt.DataAccess.Contracts.Providers;
using MyArt.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace MyArt.DataAccess.Providers
{
    public class ArtProvider : BaseProvider<Art>, IArtProvider
    {
        private readonly DbSet<Art> _artEntities;

        public ArtProvider(IDataProvider dataProvider) : base(dataProvider)
        {
            _artEntities = dataProvider.GetSet<Art>();
        }
        public async override Task<Art> GetItemByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _artEntities.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }
    }
}
