using MyArt.API.ViewModels;

namespace MyArt.BusinessLogic.Contracts
{
    public interface IBoardService
    {
        Task AddLikeByIdAsync(int boardId, CancellationToken cancellationToken);
        Task UpdateShareToBoardByIdAsync(int boardId, CancellationToken cancellationToken);
        Task<List<ShortBoardViewModel>> GetAllBoardsAsync(int page, int size, CancellationToken cancellationToken);
        Task<List<ShortBoardViewModel>> GetAllUserBoardsAsync(int page, int size, CancellationToken cancellationToken);

    }
}
