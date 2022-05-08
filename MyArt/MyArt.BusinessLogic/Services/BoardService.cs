
using MyArt.API.ViewModels;
using MyArt.BusinessLogic.Contracts;
using MyArt.DataAccess.Contracts;
using MyArt.DataAccess.Contracts.Providers;
using MyArt.DataAccess.Contracts.Repositories;

namespace MyArt.BusinessLogic.Services
{
    public class BoardService : IBoardService
    {
        private readonly IDataContext _db;
        private readonly IBoardProvider _boardProvider;
        private readonly IBoardRepository _boardRepository;

        public BoardService(
            IDataContext dataContext,
            IBoardProvider boardProvider,
            IBoardRepository boardRepository)
        {
            _db = dataContext;
            _boardProvider = boardProvider;
            _boardRepository = boardRepository;
        }

        public async Task<List<ShortBoardViewModel>> GetAllBoardsAsync(int page, int size, CancellationToken cancellationToken)
        {
            var boards = await _boardProvider.GetAllItemsAsync(page, size, cancellationToken);

            return boards;
        }
    }
}
