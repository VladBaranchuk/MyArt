using Microsoft.EntityFrameworkCore;
using MyArt.DataAccess.Contracts;
using MyArt.DataAccess.Contracts.Providers;
using MyArt.Domain.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MyArt.DataAccess.Providers
{
    public class ArtFormProvider : BaseProvider<ArtForm>, IArtFormProvider
    {
        private readonly DbSet<ArtForm> _artFormEntities;

        public ArtFormProvider(IDataProvider dataProvider) : base(dataProvider)
        {
            _artFormEntities = dataProvider.GetSet<ArtForm>();
        }

        public async override Task<ArtForm> GetItemByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _artFormEntities.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task<int> GetIdByItemAsync(string name, CancellationToken cancellationToken)
        {var item = await _artFormEntities.Where(x => x.Name == name).FirstOrDefaultAsync(cancellationToken);
            return item.Id;
        }
    }
}
