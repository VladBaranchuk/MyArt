using MyArt.API.ViewModels;
using MyArt.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MyArt.DataAccess.Contracts.Providers
{
    public interface IFilmProvider : IProvider<Film>
    {
        Task<int> GetLikesCountByIdAsync(int id, CancellationToken cancellationToken);
        Task<int> GetCommentsCountByIdAsync(int id, CancellationToken cancellationToken);
        Task<List<CommentViewModel>> GetCommentsByIdAsync(int id, CancellationToken cancellationToken);
        Task<bool> HasLikedFilmByIdAsync(int userId, int filmId, CancellationToken cancellationToken);
    }
}
