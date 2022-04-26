using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyArt.API.Helpers;
using MyArt.API.ViewModels;
using MyArt.BusinessLogic.Contracts;

namespace MyArt.API.Controllers
{
    [Route("api/films")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IFilmService _filmService;

        public FilmController(
            IHttpContextAccessor httpContextAccessor,
            IFilmService filmService)
        {
            _httpContextAccessor = httpContextAccessor;
            _filmService = filmService;
        }

        [Route("{id}")]
        [HttpGet(Name = nameof(GetFilmById))]
        public async Task<ActionResult<FilmViewModel>> GetFilmById(int id)
        {
            //_authValidator.ValidateAndThrow(authVM);

            var cancellationToken = _httpContextAccessor.HttpContext?.RequestAborted ?? CancellationToken.None;
            var result = await _filmService.GetFilmByIdAsync(id, cancellationToken);

            return Ok(result);
        }

        [Route("all")]
        [HttpGet(Name = nameof(GetFilms))]
        public async Task<ActionResult<ShortFilmViewModel>> GetFilms([FromQuery] int page = 0, [FromQuery] int size = 15)
        {
            //_authValidator.ValidateAndThrow(authVM);

            var cancellationToken = _httpContextAccessor.HttpContext?.RequestAborted ?? CancellationToken.None;
            var result = await _filmService.GetAllFilmsAsync(page, size, cancellationToken);

            return Ok(result);
        }

        [Authorize]
        [Route("like/{id}")]
        [HttpPut(Name = nameof(AddLikeToFilmById))]
        public async Task<IActionResult> AddLikeToFilmById(int id)
        {
            //_authValidator.ValidateAndThrow(authVM);

            var cancellationToken = _httpContextAccessor.HttpContext?.RequestAborted ?? CancellationToken.None;
            await _filmService.AddLikeByIdAsync(id, cancellationToken);

            return Ok();
        }

        [Authorize]
        [Route("comment")]
        [HttpPut(Name = nameof(AddCommentToFilmById))]
        public async Task<IActionResult> AddCommentToFilmById(CreateCommentViewModel comment)
        {
            //_authValidator.ValidateAndThrow(authVM);

            var cancellationToken = _httpContextAccessor.HttpContext?.RequestAborted ?? CancellationToken.None;
            await _filmService.AddCommentByIdAsync(comment, cancellationToken);

            return Ok();
        }

        [Authorize(Roles = Constants.ModeratorRole)]
        [HttpPost(Name = nameof(AddFilm))]
        public async Task<ActionResult<FilmViewModel>> AddFilm(CreateFilmViewModel film)
        {
            //_authValidator.ValidateAndThrow(authVM);

            var cancellationToken = _httpContextAccessor.HttpContext?.RequestAborted ?? CancellationToken.None;
            var result = await _filmService.AddFilmAsync(film, cancellationToken);

            return CreatedAtAction(nameof(GetFilmById), new { id = result.Id }, result);
        }
    }
}
