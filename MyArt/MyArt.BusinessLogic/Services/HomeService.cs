using MyArt.API.ViewModels;
using MyArt.BusinessLogic.Contracts;
using MyArt.DataAccess.Contracts.Providers;

namespace MyArt.BusinessLogic.Services
{
    public class HomeService : IHomeService
    {
        private readonly IArtProvider _artProvider;
        private readonly IBoardService _boardService;
        private readonly IUserService _userService;

        public HomeService(
            IUserService userService,
            IBoardService boardService,
            IArtProvider artProvider)
        {
            _artProvider = artProvider;
            _boardService = boardService;
            _userService = userService;
        }

        public async Task<HomeViewModel> GetAllAsync(int page, int size, CancellationToken cancellationToken)
        {
            var arts = await _artProvider.GetAllItemsAsync(page, size, 0, cancellationToken);
            var boards = await _boardService.GetAllBoardsAsync(page, size, cancellationToken);
            var authors = await _userService.GetAllAuthorsAsync(page, size, cancellationToken);

            var home = new HomeViewModel()
            {
                Arts = arts,
                Boards = boards,
                Authors = authors
            };

            return home;
        }
    }
}
