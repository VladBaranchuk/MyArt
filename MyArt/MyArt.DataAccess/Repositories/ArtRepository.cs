using Microsoft.EntityFrameworkCore;
using MyArt.DataAccess.Contracts;
using MyArt.DataAccess.Contracts.Repositories;
using MyArt.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace MyArt.DataAccess.Repositories
{
    public class ArtRepository : BaseRepository<Art>, IArtRepository
    {
        private readonly DbSet<LikeArts> _likeArtsEntities;
        private readonly DbSet<ArtComments> _artCommentsEntities;

        public ArtRepository(IDataProvider dataProvider) : base(dataProvider)
        {
            _likeArtsEntities = dataProvider.GetSet<LikeArts>();
            _artCommentsEntities = dataProvider.GetSet<ArtComments>();
        }

        public Task AddCommentAsync(ArtComments comment, CancellationToken cancellationToken)
        {
            _artCommentsEntities.Add(comment);
            return Task.CompletedTask;
        }
        public Task AddLikeAsync(LikeArts likeArts, CancellationToken cancellationToken)
        {
            _likeArtsEntities.Add(likeArts);
            return Task.CompletedTask;
        }
        public Task RemoveLikeAsync(LikeArts likeArts, CancellationToken cancellationToken)
        {
            _likeArtsEntities.Remove(likeArts);
            return Task.CompletedTask;
        }
    }
}
