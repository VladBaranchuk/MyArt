using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyArt.API.Infrastructure.Models;
using MyArt.API.ViewModels;
using MyArt.BusinessLogic.Contracts;
using System.Net.Mime;

namespace MyArt.API.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserService _userService;
        private readonly ICurrentUserService _currentUserService;
        private readonly IJwtService _jwtService;
        private readonly IValidator<RegisterViewModel> _registerValidator;
        private readonly IValidator<AuthenticationViewModel> _authValidator;

        public UserController(
            IHttpContextAccessor httpContextAccessor,
            IValidator<RegisterViewModel> registerValidator,
            IValidator<AuthenticationViewModel> authValidator,
            ICurrentUserService currenUserService,
            IJwtService jwtService,
            IUserService userService)
        {
            _httpContextAccessor = httpContextAccessor;
            _userService = userService;
            _registerValidator = registerValidator;
            _authValidator = authValidator;
            _jwtService = jwtService;
            _currentUserService = currenUserService;
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
            //_authValidator.ValidateAndThrow(authVM);

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
        public async Task<ActionResult<ShortArtViewModel>> GetAccount([FromQuery] string alias)
        {
            //_authValidator.ValidateAndThrow(authVM);

            var cancellationToken = _httpContextAccessor.HttpContext?.RequestAborted ?? CancellationToken.None;
            var result = await _userService.GetAccountAsync(alias, cancellationToken);

            return Ok(result);
        }
    }
}
