using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyArt.API.Infrastructure.Models;
using MyArt.API.ViewModels;
using MyArt.BusinessLogic.Contracts;
using MyArt.BusinessLogic.Services;
using System.Net.Mime;

namespace MyArt.API.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;
        private readonly ICurrentUserService _currentUserService;
        private readonly IJwtService _jwtService;
        private readonly IValidator<RegisterViewModel> _registerValidator;
        private readonly IValidator<AuthenticationViewModel> _authValidator;
        private readonly IValidator<UpdatePublicUserInfoViewModel> _updateValidator;

        public UserController(
            IHttpContextAccessor httpContextAccessor,
            IValidator<RegisterViewModel> registerValidator,
            IValidator<AuthenticationViewModel> authValidator,
            IValidator<UpdatePublicUserInfoViewModel> updateValidator,
            ICurrentUserService currenUserService,
            IJwtService jwtService,
            IEmailService emailService,
            IUserService userService)
        {
            _httpContextAccessor = httpContextAccessor;
            _userService = userService;
            _emailService = emailService;
            _registerValidator = registerValidator;
            _authValidator = authValidator;
            _jwtService = jwtService;
            _currentUserService = currenUserService;
            _updateValidator = updateValidator;
        }

        [Authorize]
        [Route("info")]
        [HttpPost(Name = nameof(GetUserInfo))]
        public async Task<ActionResult<ShortUserInfoViewModel>> GetUserInfo()
        {
            var cancellationToken = _httpContextAccessor.HttpContext?.RequestAborted ?? CancellationToken.None;
            var result = await _currentUserService.GetShortCurrentUserInfoAsync(cancellationToken);

            return Ok(result);
        }

        [Authorize]
        [Route("email")]
        [HttpPost(Name = nameof(SendMail))]
        public async Task<IActionResult> SendMail(MailViewModel mailViewModel)
        {
            //_registerValidator.ValidateAndThrow(registerVM);

            var cancellationToken = _httpContextAccessor.HttpContext?.RequestAborted ?? CancellationToken.None;
            await _emailService.SendEmailAsync(mailViewModel, cancellationToken);

            return Ok();
        }


        [Route("all")]
        [HttpPost(Name = nameof(GetAuthors))]
        public async Task<ActionResult<List<AuthorViewModel>>> GetAuthors([FromQuery] int page = 0, [FromQuery] int size = 15)
        {
            var cancellationToken = _httpContextAccessor.HttpContext?.RequestAborted ?? CancellationToken.None;
            var result = await _userService.GetAllAuthorsAsync(page, size, cancellationToken);

            return Ok(result);
        }

        [Route("filter")]
        [HttpPut(Name = nameof(GetFilterAuthors))]
        public async Task<ActionResult<AuthorViewModel>> GetFilterAuthors([FromForm] AuthorFilterViewModel authorFilterViewModel, [FromQuery] int page = 0, [FromQuery] int size = 10)
        {
            //_authValidator.ValidateAndThrow(authVM);

            var cancellationToken = _httpContextAccessor.HttpContext?.RequestAborted ?? CancellationToken.None;
            var result = await _userService.GetAllByAuthorsFilterAsync(authorFilterViewModel, page, size, cancellationToken);

            return Ok(result);
        }

        [Authorize]
        [Route("cabinet")]
        [HttpGet(Name = nameof(GetCabinet))]
        public async Task<ActionResult<CabinetViewModel>> GetCabinet()
        {
            var cancellationToken = _httpContextAccessor.HttpContext?.RequestAborted ?? CancellationToken.None;
            var result = await _userService.GetCabinetAsync(cancellationToken);

            return Ok(result);
        }

        [Authorize]
        [Route("headerInfo")]
        [HttpPost(Name = nameof(GetHeaderUserInfo))]
        public async Task<ActionResult<HeaderUserInfoViewModel>> GetHeaderUserInfo()
        {
            var cancellationToken = _httpContextAccessor.HttpContext?.RequestAborted ?? CancellationToken.None;
            var result = await _userService.GetHeaderUserInfoAsync(cancellationToken);

            return Ok(result);
        }

        [Route("signup")]
        [HttpPost(Name = nameof(SignUp))]
        public async Task<IActionResult> SignUp(RegisterViewModel registerVM)
        {
            _registerValidator.ValidateAndThrow(registerVM);

            var cancellationToken = _httpContextAccessor.HttpContext?.RequestAborted ?? CancellationToken.None;
            await _userService.RegisterAsync(registerVM, cancellationToken);

            return Ok();
        }

        [Route("signin")]
        [HttpPost(Name = nameof(SignIn))]
        public async Task<ActionResult<JwtResponse>> SignIn(AuthenticationViewModel authVM)
        {
            _authValidator.ValidateAndThrow(authVM);

            var cancellationToken = _httpContextAccessor.HttpContext?.RequestAborted ?? CancellationToken.None;
            var jwt = await _userService.AuthenticateAsync(authVM, cancellationToken);

            return Ok(new JwtResponse { Token = jwt });
        }

        [Authorize]
        [Route("{id}")]
        [HttpPut(Name = nameof(UpdatePublicUserInfo))]
        public async Task<ActionResult<UpdatePublicUserInfoViewModel>> UpdatePublicUserInfo(UpdatePublicUserInfoViewModel updatePublicUserInfoVM)
        {
            _updateValidator.ValidateAndThrow(updatePublicUserInfoVM);

            var cancellationToken = _httpContextAccessor.HttpContext?.RequestAborted ?? CancellationToken.None;
            var result = await _userService.UpdatePublicUserInfoAsync(updatePublicUserInfoVM, cancellationToken);

            return Ok(result);
        }

        [Route("image/{id}")]
        [HttpGet(Name = nameof(GetAvatar))]
        public async Task<ActionResult<byte[]>> GetAvatar(int id)
        {
            var cancellationToken = _httpContextAccessor.HttpContext?.RequestAborted ?? CancellationToken.None;
            var result = await _userService.GetAvatarAsync(id, cancellationToken);

            return File(result, MediaTypeNames.Image.Jpeg);
        }

        [Route("image/hasAny/{id}")]
        [HttpGet(Name = nameof(HasAnyAvatar))]
        public async Task<ActionResult<byte[]>> HasAnyAvatar(int id)
        {
            var cancellationToken = _httpContextAccessor.HttpContext?.RequestAborted ?? CancellationToken.None;
            var result = await _userService.HasAnyAvatarAsync(id, cancellationToken);

            return Ok(result);
        }

        [Authorize]
        [Route("updateAvatar")]
        [HttpGet(Name = nameof(UpdateAvatar))]
        public async Task<IActionResult> UpdateAvatar([FromForm] UpdateAvatarViewModel avatar)
        {
            var cancellationToken = _httpContextAccessor.HttpContext?.RequestAborted ?? CancellationToken.None;
            await _userService.UpdateAvatarAsync(avatar, cancellationToken);

            return Ok();
        }

        [Route("account")]
        [HttpGet(Name = nameof(GetAccount))]
        public async Task<ActionResult<AccountViewModel>> GetAccount([FromQuery] string alias)
        {
            //_authValidator.ValidateAndThrow(authVM);

            var cancellationToken = _httpContextAccessor.HttpContext?.RequestAborted ?? CancellationToken.None;
            var result = await _userService.GetAccountAsync(alias, cancellationToken);

            return Ok(result);
        }
    }
}
