using Microsoft.EntityFrameworkCore;
using MyArt.DataAccess.Contracts;
using MyArt.DataAccess.Contracts.Repositories;
using MyArt.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace MyArt.DataAccess.Repositories
{
    public class BoardRepository : BaseRepository<Board>, IBoardRepository
    {
        private readonly DbSet<LikeBoards> _likeBoardsEntities;
        private readonly DbSet<ArtToBoard> _artToBoardsEntities;

        public BoardRepository(IDataProvider dataProvider) : base(dataProvider)
        {
            _likeBoardsEntities = dataProvider.GetSet<LikeBoards>();
            _artToBoardsEntities = dataProvider.GetSet<ArtToBoard>();
        }

        public Task AddLikeAsync(LikeBoards likeBoards, CancellationToken cancellationToken)
        {
            _likeBoardsEntities.Add(likeBoards);
            return Task.CompletedTask;
        }
        public Task AddArtToBoard(ArtToBoard item, CancellationToken cancellationToken)
        {
            _artToBoardsEntities.Add(item);
            return Task.CompletedTask;
        }
        public Task RemoveArtFromBoard(ArtToBoard item, CancellationToken cancellationToken)
        {
            _artToBoardsEntities.Remove(item);
            return Task.CompletedTask;
        }
        public Task RemoveLikeAsync(LikeBoards likeBoards, CancellationToken cancellationToken)
        {
            _likeBoardsEntities.Remove(likeBoards);
            return Task.CompletedTask;
        }
    }
}
