using Microsoft.EntityFrameworkCore;
using MyArt.DataAccess.Contracts;
using MyArt.DataAccess.Contracts.Repositories;
using MyArt.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace MyArt.DataAccess.Repositories
{
    public class FilmRepository : BaseRepository<Film>, IFilmRepository
    {
        private readonly DbSet<LikeFilms> _likeFilmsEntities;

        public FilmRepository(IDataProvider dataProvider) : base(dataProvider)
        {
            _likeFilmsEntities = dataProvider.GetSet<LikeFilms>();
        }

        public Task SetLike(LikeFilms likeFilms, CancellationToken cancellationToken)
        {
            _likeFilmsEntities.Add(likeFilms);
            return Task.CompletedTask;
        }
        public Task RemoveLike(LikeFilms likeFilms, CancellationToken cancellationToken)
        {
            _likeFilmsEntities.Remove(likeFilms);
            return Task.CompletedTask;
        }
    }
}
