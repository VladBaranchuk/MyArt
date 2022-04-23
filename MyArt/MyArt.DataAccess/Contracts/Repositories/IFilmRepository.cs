using MyArt.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace MyArt.DataAccess.Contracts.Repositories
{
    public interface IFilmRepository : IRepository<Film>
    {
        Task SetLike(LikeFilms likeFilms, CancellationToken cancellationToken);
        Task RemoveLike(LikeFilms likeFilms, CancellationToken cancellationToken);
    }
}
