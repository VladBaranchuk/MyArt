using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyArt.API.ViewModels;
using MyArt.DataAccess.Contracts;
using MyArt.DataAccess.Contracts.Providers;
using MyArt.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MyArt.DataAccess.Providers
{
    public class BoardProvider : BaseProvider<Board>, IBoardProvider
    {
        private readonly IMapper _mapper;
        private readonly DbSet<Board> _boardEntities;
        private readonly DbSet<LikeBoards> _likeBoardsEntities;

        public BoardProvider(IDataProvider dataProvider, IMapper mapper) : base(dataProvider)
        {
            _mapper = mapper;
            _boardEntities = dataProvider.GetSet<Board>();
            _likeBoardsEntities = dataProvider.GetSet<LikeBoards>();
        }

        public async Task<List<ShortBoardViewModel>> GetAllItemsAsync(int page, int size, CancellationToken cancellationToken)
        {
            var query = _boardEntities
                .OrderBy(x => x.Id)
                .Skip(page * size)
                .Take(size)
                .Select(x => new ShortBoardViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Alias = x.User.Alias,
                    FirstId = x.ArtToBoards.FirstOrDefault().ArtId,
                    ShareCount = (int)x.ShareCount,
                    LikesCount = x.LikeBoards.Count()
                });

            return await _mapper.ProjectTo<ShortBoardViewModel>(query).ToListAsync(cancellationToken);
        }
        public async Task<int> GetFirstArtIdFromBoardAsync(int boardId, CancellationToken cancellationToken)
        {
            var result = await _boardEntities
                .Where(x => x.Id == boardId)
                .Select(x => x.ArtToBoards.FirstOrDefault().ArtId)
                .FirstOrDefaultAsync(cancellationToken);

            return result;
        }
        public async Task<int> GetLikesCountByIdAsync(int boardId, CancellationToken cancellationToken)
        {
            var count = await _likeBoardsEntities.Where(x => x.BoardId == boardId).CountAsync(cancellationToken);
            return count;
        }
        public async Task<List<ShortBoardViewModel>> GetAllUserItemsAsync(int userId, int page, int size, CancellationToken cancellationToken)
        {
            var query = _boardEntities
                .Where(x => x.UserId == userId)
                .OrderBy(x => x.Id)
                .Skip(page * size)
                .Take(size)
                .Select(x => new ShortBoardViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Alias = x.User.Alias,
                    FirstId = x.ArtToBoards.FirstOrDefault().ArtId,
                    ShareCount = (int)x.ShareCount,
                    LikesCount = x.LikeBoards.Count()
                });

            return await _mapper.ProjectTo<ShortBoardViewModel>(query).ToListAsync(cancellationToken);
        }
        public async Task<List<UserboardViewModel>> GetAllUserboardsAsync(int userId, int artId, CancellationToken cancellationToken)
        {
            var query = _boardEntities
                .Where(x => x.UserId == userId)
                .OrderBy(x => x.Id)
                .Select(x => new UserboardViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    FirstId = x.ArtToBoards.FirstOrDefault().ArtId,
                    HasChecked = x.ArtToBoards.Any(x => x.ArtId == artId)
                });

            return await _mapper.ProjectTo<UserboardViewModel>(query).ToListAsync(cancellationToken);
        }
        public async Task<bool> HasLikedBoardByIdAsync(int userId, int boardId, CancellationToken cancellationToken)
        {
            var hasLiked = await _likeBoardsEntities
               .Where(x => x.BoardId == boardId)
               .AnyAsync(x => x.UserId == userId, cancellationToken);

            return hasLiked;
        }
        public async override Task<Board> GetItemByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _boardEntities.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }
    }
}
