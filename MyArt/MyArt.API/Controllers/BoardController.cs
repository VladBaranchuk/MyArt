using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyArt.API.ViewModels;
using MyArt.BusinessLogic.Contracts;

namespace MyArt.API.Controllers
{
    [Route("api/boards")]
    [ApiController]
    public class BoardController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IBoardService _boardService;

        public BoardController(
            IHttpContextAccessor httpContextAccessor,
            IBoardService boardService)
        {
            _httpContextAccessor = httpContextAccessor;
            _boardService = boardService;
        }

        [Route("{id}")]
        [HttpGet(Name = nameof(GetBoardById))]
        public async Task<ActionResult<BoardViewModel>> GetBoardById(int id)
        {
            //_authValidator.ValidateAndThrow(authVM);

            var cancellationToken = _httpContextAccessor.HttpContext?.RequestAborted ?? CancellationToken.None;
            var result = await _boardService.GetBoardByIdAsync(id, cancellationToken);

            return Ok(result);
        }

        [Route("all")]
        [HttpGet(Name = nameof(GetBoards))]
        public async Task<ActionResult<ShortBoardViewModel>> GetBoards([FromQuery] int page = 0, [FromQuery] int size = 15)
        {
            //_authValidator.ValidateAndThrow(authVM);

            var cancellationToken = _httpContextAccessor.HttpContext?.RequestAborted ?? CancellationToken.None;
            var result = await _boardService.GetAllBoardsAsync(page, size, cancellationToken);

            return Ok(result);
        }

        [Route("user")]
        [HttpGet(Name = nameof(GetUserBoards))]
        public async Task<ActionResult<ShortBoardViewModel>> GetUserBoards([FromQuery] int page = 0, [FromQuery] int size = 15)
        {
            //_authValidator.ValidateAndThrow(authVM);

            var cancellationToken = _httpContextAccessor.HttpContext?.RequestAborted ?? CancellationToken.None;
            var result = await _boardService.GetAllUserBoardsAsync(page, size, cancellationToken);

            return Ok(result);
        }

        [Authorize]
        [Route("userboards/{id}")]
        [HttpGet(Name = nameof(GetUserBoards))]
        public async Task<ActionResult<UserboardsViewModel>> GetUserBoards(int id)
        {
            //_authValidator.ValidateAndThrow(authVM);

            var cancellationToken = _httpContextAccessor.HttpContext?.RequestAborted ?? CancellationToken.None;
            var result = await _boardService.GetAllUserboardsAsync(id, cancellationToken);

            return Ok(result);
        }

        [Authorize]
        [Route("userboards/update/{id}")]
        [HttpPut(Name = nameof(UpdateUserBoards))]
        public async Task<IActionResult> UpdateUserBoards(int id, [FromBody] int[] ids)
        {
            //_authValidator.ValidateAndThrow(authVM);

            var cancellationToken = _httpContextAccessor.HttpContext?.RequestAborted ?? CancellationToken.None;
            await _boardService.UpdateUserboardsAsync(id, ids, cancellationToken);

            return Ok();
        }

        [Route("share/{id}")]
        [HttpPut(Name = nameof(UpdateShareToBoardById))]
        public async Task<IActionResult> UpdateShareToBoardById(int id)
        {
            //_authValidator.ValidateAndThrow(authVM);

            var cancellationToken = _httpContextAccessor.HttpContext?.RequestAborted ?? CancellationToken.None;
            await _boardService.UpdateShareToBoardByIdAsync(id, cancellationToken);

            return Ok();
        }

        [Authorize]
        [Route("like/{id}")]
        [HttpPut(Name = nameof(AddLikeToBoardById))]
        public async Task<IActionResult> AddLikeToBoardById(int id)
        {
            //_authValidator.ValidateAndThrow(authVM);

            var cancellationToken = _httpContextAccessor.HttpContext?.RequestAborted ?? CancellationToken.None;
            await _boardService.AddLikeByIdAsync(id, cancellationToken);

            return Ok();
        }

        [Authorize]
        [HttpPost(Name = nameof(AddBoard))]
        public async Task<IActionResult> AddBoard(CreateBoardViewModel createBoardViewModel)
        {
            //_authValidator.ValidateAndThrow(authVM);

            var cancellationToken = _httpContextAccessor.HttpContext?.RequestAborted ?? CancellationToken.None;
            await _boardService.AddBoardAsync(createBoardViewModel, cancellationToken);

            return Ok();
        }
    }
}
