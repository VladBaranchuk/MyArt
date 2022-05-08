using Microsoft.AspNetCore.Http;
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

        [Route("all")]
        [HttpGet(Name = nameof(GetBoards))]
        public async Task<ActionResult<ShortBoardViewModel>> GetBoards([FromQuery] int page = 0, [FromQuery] int size = 15)
        {
            //_authValidator.ValidateAndThrow(authVM);

            var cancellationToken = _httpContextAccessor.HttpContext?.RequestAborted ?? CancellationToken.None;
            var result = await _boardService.GetAllBoardsAsync(page, size, cancellationToken);

            return Ok(result);
        }
    }
}
