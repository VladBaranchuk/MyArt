
using MyArt.API.ViewModels;
using MyArt.BusinessLogic.Contracts;
using MyArt.DataAccess.Contracts;
using MyArt.DataAccess.Contracts.Providers;
using MyArt.DataAccess.Contracts.Repositories;
using MyArt.Domain.Entities;

namespace MyArt.BusinessLogic.Services
{
    public class BoardService : IBoardService
    {
        private readonly IDataContext _db;
        private readonly IBoardProvider _boardProvider;
        private readonly IBoardRepository _boardRepository;
        private readonly ICurrentUserService _currentUserService;

        public BoardService(
            IDataContext dataContext,
            IBoardProvider boardProvider,
            IBoardRepository boardRepository,
            ICurrentUserService currentUserService)
        {
            _db = dataContext;
            _boardProvider = boardProvider;
            _boardRepository = boardRepository;
            _currentUserService = currentUserService;
        }

        public async Task AddLikeByIdAsync(int boardId, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.GetUserIdByHttpContext(cancellationToken);

            var hasLiked = await _boardProvider.HasLikedBoardByIdAsync(userId, boardId, cancellationToken);

            var like = new LikeBoards()
            {
                UserId = userId,
                BoardId = boardId
            };

            if (hasLiked)
            {
                await _boardRepository.RemoveLikeAsync(like, cancellationToken);
            }
            else
            {
                await _boardRepository.AddLikeAsync(like, cancellationToken);
            }

            await _db.SaveChangesAsync(cancellationToken);
        }
        public async Task<List<ShortBoardViewModel>> GetAllBoardsAsync(int page, int size, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.GetUserIdByHttpContext(cancellationToken);

            var boards = await _boardProvider.GetAllItemsAsync(page, size, cancellationToken);

            foreach (var board in boards)
            {
                var hasLiked = await _boardProvider.HasLikedBoardByIdAsync(userId, board.Id, cancellationToken);

                if (hasLiked)
                {
                    board.HasLiked = true;
                }
                else
                {
                    board.HasLiked = false;
                }
                
            }

            return boards;
        }
        public async Task<List<ShortBoardViewModel>> GetAllUserBoardsAsync(int page, int size, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.GetUserIdByHttpContext(cancellationToken);

            var boards = await _boardProvider.GetAllUserItemsAsync(userId, page, size, cancellationToken);

            foreach (var board in boards)
            {
                var hasLiked = await _boardProvider.HasLikedBoardByIdAsync(userId, board.Id, cancellationToken);

                if (hasLiked)
                {
                    board.HasLiked = true;
                }
                else
                {
                    board.HasLiked = false;
                }

            }

            return boards;
        }
        public async Task<UserboardsViewModel> GetAllUserboardsAsync(int artId, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.GetUserIdByHttpContext(cancellationToken);

            var userboards = await _boardProvider.GetAllUserboardsAsync(userId, artId, cancellationToken);

            var checkedIds = new List<int>();

            foreach (var userboard in userboards)
            {
                if (userboard.HasChecked)
                {
                    checkedIds.Add(userboards.IndexOf(userboard) + 1);
                }
            }

            var userboardsVM = new UserboardsViewModel()
            {
                Userboards = userboards,
                CheckedUserboards = checkedIds.ToArray()
            };

            return userboardsVM;
        }
        public async Task UpdateUserboardsAsync(int artId, int[] boardIds, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.GetUserIdByHttpContext(cancellationToken);

            var boards = await _boardProvider.GetAllUserboardsAsync(userId, artId, cancellationToken);

            foreach(var board in boards)
            {
                var hasAny = boardIds.Any(x => x == board.Id);

                if (board.HasChecked == false && hasAny == true)
                {
                    var item = new ArtToBoard()
                    {
                        ArtId = artId,
                        BoardId = board.Id
                    };

                    await _boardRepository.AddArtToBoard(item, cancellationToken);
                }
                else if(board.HasChecked == true && hasAny == false)
                {
                    var item = new ArtToBoard()
                    {
                        ArtId = artId,
                        BoardId = board.Id
                    };

                    await _boardRepository.RemoveArtFromBoard(item, cancellationToken);
                }
            }

            await _db.SaveChangesAsync(cancellationToken);
        }
        public async Task AddBoardAsync(CreateBoardViewModel boardVM, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.GetUserIdByHttpContext(cancellationToken);

            Board board = new Board()
            {
                Name = boardVM.Name,
                Visible = 0,
                ShareCount = 0,
                Date = DateTime.Now,
                UserId = userId
            };

            await _boardRepository.CreateAsync(board, cancellationToken);
            await _db.SaveChangesAsync(cancellationToken);
        }
        public async Task UpdateShareToBoardByIdAsync(int boardId, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.GetUserIdByHttpContext(cancellationToken);

            var board = await _boardProvider.GetItemByIdAsync(boardId, cancellationToken);

            board.ShareCount++;

            await _boardRepository.UpdateAsync(board, cancellationToken);
            await _db.SaveChangesAsync(cancellationToken);
        }
    }
}
