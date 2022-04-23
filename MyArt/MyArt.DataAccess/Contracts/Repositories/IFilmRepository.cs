using MyArt.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace MyArt.DataAccess.Contracts.Repositories
{
    public interface IFilmRepository : IRepository<Film>
    {
        Task AddLikeAsync(LikeFilms likeFilms, CancellationToken cancellationToken);
        Task RemoveLikeAsync(LikeFilms likeFilms, CancellationToken cancellationToken);
        Task AddCommentAsync(FilmComments comment, CancellationToken cancellationToken);
    }
}
