using FluentValidation;
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
        private readonly IEmailService _emailService;
        private readonly IValidator<ArtFilterViewModel> _filterValidator;
        private readonly IValidator<CreateArtViewModel> _createValidator;

        public ArtController(
            IHttpContextAccessor httpContextAccessor,
            IArtService artService,
            IEmailService emailService,
            IValidator<CreateArtViewModel> createValidator,
            IValidator<ArtFilterViewModel> filterValidator)
        {
            _httpContextAccessor = httpContextAccessor;
            _artService = artService;
            _emailService = emailService;
            _createValidator = createValidator;
            _filterValidator = filterValidator;
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

        [Route("user")]
        [HttpGet(Name = nameof(GetUserArts))]
        public async Task<ActionResult<ShortArtViewModel>> GetUserArts([FromQuery] int page = 0, [FromQuery] int size = 15)
        {
            //_authValidator.ValidateAndThrow(authVM);

            var cancellationToken = _httpContextAccessor.HttpContext?.RequestAborted ?? CancellationToken.None;
            var result = await _artService.GetAllUserArtsAsync(page, size, cancellationToken);

            return Ok(result);
        }

        [Route("userById")]
        [HttpGet(Name = nameof(GetUserArtsById))]
        public async Task<ActionResult<ShortArtViewModel>> GetUserArtsById([FromQuery] int page = 0, [FromQuery] int size = 15, [FromQuery] int userId = 0)
        {
            //_authValidator.ValidateAndThrow(authVM);

            var cancellationToken = _httpContextAccessor.HttpContext?.RequestAborted ?? CancellationToken.None;
            var result = await _artService.GetAllUserArtsByIdAsync(page, size, userId, cancellationToken);

            return Ok(result);
        }

        [Route("board")]
        [HttpGet(Name = nameof(GetBoardArts))]
        public async Task<ActionResult<ShortArtViewModel>> GetBoardArts([FromQuery] int page = 0, [FromQuery] int size = 15, [FromQuery] int boardId = 0)
        {
            //_authValidator.ValidateAndThrow(authVM);

            var cancellationToken = _httpContextAccessor.HttpContext?.RequestAborted ?? CancellationToken.None;
            var result = await _artService.GetAllBoardArtsAsync(page, size, boardId, cancellationToken);

            return Ok(result);
        }

        [Route("filter")]
        [HttpPut(Name = nameof(GetFilterArts))]
        public async Task<ActionResult<ShortArtViewModel>> GetFilterArts([FromForm] ArtFilterViewModel artFilterViewModel, [FromQuery] int page = 0, [FromQuery] int size = 10)
        {
            _filterValidator.ValidateAndThrow(artFilterViewModel);

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
            await _emailService.SendEmailAboutCommentAsync(comment, cancellationToken);

            return Ok(result);
        }

        [Authorize]
        [Route("upload")]
        [HttpPost(Name = nameof(AddArt))]
        public async Task<IActionResult> AddArt([FromForm] CreateArtViewModel img)
        {
            _createValidator.ValidateAndThrow(img);

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

        [Route("sale/{id}")]
        [HttpPut(Name = nameof(BuyArt))]
        public async Task<IActionResult> BuyArt(int id)
        {
            var cancellationToken = _httpContextAccessor.HttpContext?.RequestAborted ?? CancellationToken.None;
            await _artService.BuyArtAsync(id, cancellationToken);
            await _emailService.SendEmailAboutBouhtAsync(id, cancellationToken);
            await _emailService.SendEmailAboutBouhtToArtistAsync(id, cancellationToken);

            return Ok();
        }
    }
}
