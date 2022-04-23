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
        private readonly DbSet<FilmComments> _filmCommentsEntities;

        public FilmRepository(IDataProvider dataProvider) : base(dataProvider)
        {
            _likeFilmsEntities = dataProvider.GetSet<LikeFilms>();
            _filmCommentsEntities = dataProvider.GetSet<FilmComments>();    
        }

        public Task AddLikeAsync(LikeFilms likeFilms, CancellationToken cancellationToken)
        {
            _likeFilmsEntities.Add(likeFilms);
            return Task.CompletedTask;
        }
        public Task RemoveLikeAsync(LikeFilms likeFilms, CancellationToken cancellationToken)
        {
            _likeFilmsEntities.Remove(likeFilms);
            return Task.CompletedTask;
        }
        public Task AddCommentAsync(FilmComments comment, CancellationToken cancellationToken)
        {
            _filmCommentsEntities.Add(comment);
            return Task.CompletedTask;
        }
    }
}
