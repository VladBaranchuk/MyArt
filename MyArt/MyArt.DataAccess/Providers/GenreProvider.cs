using Microsoft.EntityFrameworkCore;
using MyArt.DataAccess.Contracts;
using MyArt.DataAccess.Contracts.Providers;
using MyArt.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace MyArt.DataAccess.Providers
{
    public class GenreProvider : BaseProvider<Genre>, IGenreProvider
    {
        private readonly DbSet<Genre> _genreEntities;

        public GenreProvider(IDataProvider dataProvider) : base(dataProvider)
        {
            _genreEntities = dataProvider.GetSet<Genre>();
        }

        public async override Task<Genre> GetItemByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _genreEntities.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }
    }
}
