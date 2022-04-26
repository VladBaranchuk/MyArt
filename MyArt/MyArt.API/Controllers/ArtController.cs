using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyArt.API.ViewModels;
using MyArt.BusinessLogic.Contracts;

namespace MyArt.API.Controllers
{
    [Route("api/arts")]
    [ApiController]
    public class ArtController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IArtService _artService;

        public ArtController(
            IHttpContextAccessor httpContextAccessor,
            IArtService artService)
        {
            _httpContextAccessor = httpContextAccessor;
            _artService = artService;
        }

        [Route("{id}")]
        [HttpGet(Name = nameof(GetArtById))]
        public async Task<ActionResult<ArtViewModel>> GetArtById(int id)
        {
            //_authValidator.ValidateAndThrow(authVM);

            var cancellationToken = _httpContextAccessor.HttpContext?.RequestAborted ?? CancellationToken.None;
            var result = await _artService.GetArtByIdAsync(id, cancellationToken);

            return Ok(result);
        }

        [Route("all")]
        [HttpGet(Name = nameof(GetArts))]
        public async Task<ActionResult<ShortArtViewModel>> GetArts([FromQuery] int page = 0, [FromQuery] int size = 15)
        {
            //_authValidator.ValidateAndThrow(authVM);

            var cancellationToken = _httpContextAccessor.HttpContext?.RequestAborted ?? CancellationToken.None;
            var result = await _artService.GetAllArtsAsync(page, size, cancellationToken);

            return Ok(result);
        }

        [Authorize]
        [Route("like/{id}")]
        [HttpPut(Name = nameof(AddLikeToArtById))]
        public async Task<IActionResult> AddLikeToArtById(int id)
        {
            //_authValidator.ValidateAndThrow(authVM);

            var cancellationToken = _httpContextAccessor.HttpContext?.RequestAborted ?? CancellationToken.None;
            await _artService.AddLikeByIdAsync(id, cancellationToken);

            return Ok();
        }

        [Authorize]
        [Route("comment")]
        [HttpPut(Name = nameof(AddCommentToArtById))]
        public async Task<IActionResult> AddCommentToArtById(CreateCommentViewModel comment)
        {
            //_authValidator.ValidateAndThrow(authVM);

            var cancellationToken = _httpContextAccessor.HttpContext?.RequestAborted ?? CancellationToken.None;
            await _artService.AddCommentByIdAsync(comment, cancellationToken);

            return Ok();
        }

        [Authorize]
        [HttpPost(Name = nameof(AddArt))]
        public async Task<ActionResult<FilmViewModel>> AddArt(CreateArtViewModel art)
        {
            //_authValidator.ValidateAndThrow(authVM);

            var cancellationToken = _httpContextAccessor.HttpContext?.RequestAborted ?? CancellationToken.None;
            var result = await _artService.AddArtAsync(art, cancellationToken);

            return CreatedAtAction(nameof(GetArtById), new { id = result.Id }, result);
        }

        [Authorize]
        [HttpPost(Name = nameof(UploadArt))]
        public async Task<IActionResult> UploadArt([FromForm] CreateArtViewModel img)
        {
            var cancellationToken = _httpContextAccessor.HttpContext?.RequestAborted ?? CancellationToken.None;
            await _artService.UploadArtAsync(img, cancellationToken);

            return Ok();
        }
    }
}
