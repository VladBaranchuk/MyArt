using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyArt.API.ViewModels;
using MyArt.BusinessLogic.Contracts;
using System.Net.Mime;

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
        public async Task<ActionResult<ShortArtViewModel>> GetArts([FromQuery] int page = 0, [FromQuery] int size = 15, [FromQuery] int type = 0)
        {
            //_authValidator.ValidateAndThrow(authVM);

            var cancellationToken = _httpContextAccessor.HttpContext?.RequestAborted ?? CancellationToken.None;
            var result = await _artService.GetAllArtsAsync(page, size, type, cancellationToken);

            return Ok(result);
        }

        [Route("filter")]
        [HttpPut(Name = nameof(GetFilterArts))]
        public async Task<ActionResult<ShortArtViewModel>> GetFilterArts([FromForm] ArtFilterViewModel artFilterViewModel, [FromQuery] int page = 0, [FromQuery] int size = 10)
        {
            //_authValidator.ValidateAndThrow(authVM);

            var cancellationToken = _httpContextAccessor.HttpContext?.RequestAborted ?? CancellationToken.None;
            var result = await _artService.GetAllByArtsFilterAsync(artFilterViewModel, page, size, cancellationToken);

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

        [Route("share/{id}")]
        [HttpPut(Name = nameof(UpdateShareToArtById))]
        public async Task<IActionResult> UpdateShareToArtById(int id)
        {
            //_authValidator.ValidateAndThrow(authVM);

            var cancellationToken = _httpContextAccessor.HttpContext?.RequestAborted ?? CancellationToken.None;
            await _artService.UpdateShareToArtByIdAsync(id, cancellationToken);

            return Ok();
        }

        [Authorize]
        [Route("comment")]
        [HttpPut(Name = nameof(AddCommentToArtById))]
        public async Task<ActionResult<CommentViewModel>> AddCommentToArtById(CreateCommentViewModel comment)
        {
            //_authValidator.ValidateAndThrow(authVM);

            var cancellationToken = _httpContextAccessor.HttpContext?.RequestAborted ?? CancellationToken.None;
            var result = await _artService.AddCommentByIdAsync(comment, cancellationToken);

            return Ok(result);
        }

        [Authorize]
        [Route("upload")]
        [HttpPost(Name = nameof(AddArt))]
        public async Task<IActionResult> AddArt([FromForm] CreateArtViewModel img)
        {
            var cancellationToken = _httpContextAccessor.HttpContext?.RequestAborted ?? CancellationToken.None;
            await _artService.AddArtAsync(img, cancellationToken);

            return Ok();
        }

        [Route("image/{id}")]
        [HttpGet(Name = nameof(GetImage))]
        public async Task<ActionResult<byte[]>> GetImage(int id)
        {
            var cancellationToken = _httpContextAccessor.HttpContext?.RequestAborted ?? CancellationToken.None;
            var result = await _artService.GetImageAsync(id, cancellationToken);

            return File(result, MediaTypeNames.Image.Jpeg);
        }

        [Authorize]
        [Route("sale/{id}")]
        [HttpPut(Name = nameof(BuyArt))]
        public async Task<IActionResult> BuyArt(int id)
        {
            var cancellationToken = _httpContextAccessor.HttpContext?.RequestAborted ?? CancellationToken.None;
            await _artService.BuyArtAsync(id, cancellationToken);

            return Ok();
        }
    }
}
