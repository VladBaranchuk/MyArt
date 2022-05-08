using MyArt.API.ViewModels;

namespace MyArt.BusinessLogic.Contracts
{
    public interface IBoardService
    {
        Task<List<ShortBoardViewModel>> GetAllBoardsAsync(int page, int size, CancellationToken cancellationToken);
    }
}
