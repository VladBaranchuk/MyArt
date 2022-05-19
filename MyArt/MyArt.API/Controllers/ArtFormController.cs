using Microsoft.AspNetCore.Mvc;
using MyArt.BusinessLogic.Contracts;

namespace MyArt.API.Controllers
{
    [Route("api/artform")]
    [ApiController]
    public class ArtFormController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IArtFormService _artformService;

        public ArtFormController(IHttpContextAccessor httpContextAccessor, IArtFormService artformService)
        {
            _httpContextAccessor = httpContextAccessor;
            _artformService = artformService;
        }

        [Route("add")]
        [HttpPost(Name = nameof(AddArtForms))]
        public async Task<IActionResult> AddArtForms(int id)
        {
            var cancellationToken = _httpContextAccessor.HttpContext?.RequestAborted ?? CancellationToken.None;
            await _artformService.AddArtFormsAsync(cancellationToken);

            return Ok();
        }
    }
}
