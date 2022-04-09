using Microsoft.EntityFrameworkCore;
using MyArt.DataAccess.Contracts;
using MyArt.DataAccess.Contracts.Providers;
using MyArt.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace MyArt.DataAccess.Providers
{
    public class FilmProvider : BaseProvider<Film>, IFilmProvider
    {
        private readonly DbSet<Film> _filmEntities;

        public FilmProvider(IDataProvider dataProvider) : base(dataProvider)
        {
            _filmEntities = dataProvider.GetSet<Film>();
        }

        public async override Task<Film> GetItemByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _filmEntities.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }
    }
}
