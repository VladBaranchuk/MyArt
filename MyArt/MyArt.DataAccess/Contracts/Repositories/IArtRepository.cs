using MyArt.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace MyArt.DataAccess.Contracts.Repositories
{
    public interface IArtRepository : IRepository<Art>
    {
        Task AddLikeAsync(LikeArts likeArts, CancellationToken cancellationToken);
        Task RemoveLikeAsync(LikeArts likeArts, CancellationToken cancellationToken);
        Task AddCommentAsync(ArtComments comment, CancellationToken cancellationToken);
    }
}
