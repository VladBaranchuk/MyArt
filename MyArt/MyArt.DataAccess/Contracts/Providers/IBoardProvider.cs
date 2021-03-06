using MyArt.API.ViewModels;
using MyArt.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MyArt.DataAccess.Contracts.Providers
{
    public interface IBoardProvider : IProvider<Board>
    {
        Task<bool> HasLikedBoardByIdAsync(int userId, int boardId, CancellationToken cancellationToken);
        Task<List<ShortBoardViewModel>> GetAllItemsAsync(int page, int size, CancellationToken cancellationToken);
        Task<List<ShortBoardViewModel>> GetAllUserItemsAsync(int userId, int page, int size, CancellationToken cancellationToken);
        Task<List<UserboardViewModel>> GetAllUserboardsAsync(int userId, int artId, CancellationToken cancellationToken);
        Task<int> GetLikesCountByIdAsync(int boardId, CancellationToken cancellationToken);
        Task<int> GetFirstArtIdFromBoardAsync(int boardId, CancellationToken cancellationToken);
        Task<User> GetUserByBoardIdAsync(int boardId, CancellationToken cancellationToken);
        Task<List<ShortBoardViewModel>> GetAllByBoardsFilterAsync(BoardFilterViewModel filter, int page, int size, CancellationToken cancellationToken);
    }
}
