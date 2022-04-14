using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyArt.API.Infrastructure.Models;
using MyArt.API.ViewModels;
using MyArt.BusinessLogic.Contracts;

namespace MyArt.API.Controllers
{
    [Route("api/[controller]")]
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
        [Route("Info")]
        [HttpPost(Name = nameof(GetUserInfo))]
        public async Task<ActionResult<ShortUserInfoViewModel>> GetUserInfo()
        {
            var cancellationToken = _httpContextAccessor.HttpContext?.RequestAborted ?? CancellationToken.None;
            var result = await _currentUserService.GetShortCurrentUserInfoAsync(cancellationToken);

            return Ok(result);
        }

        [Route("Signup")]
        [HttpPost(Name = nameof(SignUp))]
        public async Task<IActionResult> SignUp(RegisterViewModel registerVM)
        {
            _registerValidator.ValidateAndThrow(registerVM);

            var cancellationToken = _httpContextAccessor.HttpContext?.RequestAborted ?? CancellationToken.None;
            await _userService.RegisterAsync(registerVM, cancellationToken);

            return Ok();
        }

        [Route("Signin")]
        [HttpPost(Name = nameof(SignIn))]
        public async Task<ActionResult> SignIn(AuthenticationViewModel authVM)
        {
            _authValidator.ValidateAndThrow(authVM);

            var cancellationToken = _httpContextAccessor.HttpContext?.RequestAborted ?? CancellationToken.None;
            var jwt = await _userService.AuthenticateAsync(authVM, cancellationToken);

            return Ok(new JwtResponse { Token = jwt });
        }
    }
}
