using Microsoft.AspNetCore.Mvc;
using MyArt.API.ViewModels;
using MyArt.BusinessLogic.Contracts;

namespace MyArt.API.Controllers
{
    [Route("api/home")]
    public class HomeController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHomeService _homeService;

        public HomeController(
            IHttpContextAccessor httpContextAccessor,
            IHomeService homeService)
        {
            _httpContextAccessor = httpContextAccessor;
            _homeService = homeService;
        }

        [HttpGet(Name = nameof(Index))]
        public async Task<ActionResult<HomeViewModel>> Index()
        {
            //_authValidator.ValidateAndThrow(authVM);

            var cancellationToken = _httpContextAccessor.HttpContext?.RequestAborted ?? CancellationToken.None;
            var result = await _homeService.GetAllAsync(0, 10, cancellationToken);

            return Ok(result);
        }
    }
}
