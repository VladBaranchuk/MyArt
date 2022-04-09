using Microsoft.EntityFrameworkCore;
using MyArt.DataAccess.Contracts;
using MyArt.DataAccess.Contracts.Providers;
using MyArt.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace MyArt.DataAccess.Providers
{
    public class ExhibitionProvider : BaseProvider<Exhibition>, IExhibitionProvider
    {
        private readonly DbSet<Exhibition> _exhibitionEntities;

        public ExhibitionProvider(IDataProvider dataProvider) : base(dataProvider)
        {
            _exhibitionEntities = dataProvider.GetSet<Exhibition>();
        }

        public async override Task<Exhibition> GetItemByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _exhibitionEntities.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }
    }
}
