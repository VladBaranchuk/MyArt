using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        [HttpGet(Name = nameof(GetFilmsDetailedInfoById))]
        public async Task<ActionResult<FilmsDetailedInfoViewModel>> GetFilmsDetailedInfoById(int id)
        {
            //_authValidator.ValidateAndThrow(authVM);

            var cancellationToken = _httpContextAccessor.HttpContext?.RequestAborted ?? CancellationToken.None;
            var result = await _filmService.GetFilmById(id, cancellationToken);

            return Ok(result);
        }

        [Authorize]
        [Route("like/{id}")]
        [HttpPut(Name = nameof(SetLikeById))]
        public async Task<IActionResult> SetLikeById(int id)
        {
            //_authValidator.ValidateAndThrow(authVM);

            var cancellationToken = _httpContextAccessor.HttpContext?.RequestAborted ?? CancellationToken.None;
            await _filmService.SetLikeById(id, cancellationToken);

            return Ok();
        }
    }
}
