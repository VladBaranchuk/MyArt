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
            var result = await _filmService.GetFilmsDetailedInfoById(id, cancellationToken);

            return Ok(result);
        }
    }
}
