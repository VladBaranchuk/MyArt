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

        public BoardRepository(IDataProvider dataProvider) : base(dataProvider)
        {
            _likeBoardsEntities = dataProvider.GetSet<LikeBoards>();
        }

        public Task AddLikeAsync(LikeBoards likeBoards, CancellationToken cancellationToken)
        {
            _likeBoardsEntities.Add(likeBoards);
            return Task.CompletedTask;
        }
        public Task RemoveLikeAsync(LikeBoards likeBoards, CancellationToken cancellationToken)
        {
            _likeBoardsEntities.Remove(likeBoards);
            return Task.CompletedTask;
        }
    }
}
