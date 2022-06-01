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
        private readonly IUserProvider _userProvider;

        public HomeService(
            IUserService userService,
            IBoardService boardService,
            IArtProvider artProvider,
            IUserProvider userProvider)
        {
            _artProvider = artProvider;
            _boardService = boardService;
            _userService = userService;
            _userProvider = userProvider;
        }

        public async Task<HomeViewModel> GetAllAsync(int page, int size, CancellationToken cancellationToken)
        {
            var filter = new ArtFilterViewModel()
            {
                MinPrice = 0,
                MaxPrice = 10000,
                Popular = true,
            };

            var arts = await _artProvider.GetAllByArtsFilterAsync(filter, page, size, cancellationToken);
            var boards = await _boardService.GetAllBoardsAsync(page, size, cancellationToken);
            var authors = await _userService.GetAllAuthorsAsync(page, size, cancellationToken);

            var authorsCount = await _userProvider.GetAllCountAsync(cancellationToken);
            var coast = await _artProvider.GetFullCoastAsync(cancellationToken);
            var artsCount = await _artProvider.GetAllCountAsync(cancellationToken);

            var home = new HomeViewModel()
            {
                Arts = arts,
                Boards = boards,
                Authors = authors,

                Coast = coast,
                CountAuthors = authorsCount,
                CountArts = artsCount
            };

            return home;
        }
    }
}
