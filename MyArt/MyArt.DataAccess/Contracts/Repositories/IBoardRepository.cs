using MyArt.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace MyArt.DataAccess.Contracts.Repositories
{
    public interface IBoardRepository : IRepository<Board>
    {
        Task AddLikeAsync(LikeBoards likeBoards, CancellationToken cancellationToken);
        Task RemoveLikeAsync(LikeBoards likeBoards, CancellationToken cancellationToken);
        Task AddArtToBoard(ArtToBoard item, CancellationToken cancellationToken);
        Task RemoveArtFromBoard(ArtToBoard item, CancellationToken cancellationToken);

    }
}
