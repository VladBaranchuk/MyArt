using Microsoft.AspNetCore.Mvc;
using MyArt.BusinessLogic.Contracts;

namespace MyArt.API.Controllers
{
    [Route("api/role")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IRoleService _roleService;

        public RoleController(
            IHttpContextAccessor httpContextAccessor,
            IRoleService roleService)
        {
            _httpContextAccessor = httpContextAccessor;
            _roleService = roleService;
        }

        [Route("add")]
        [HttpPost(Name = nameof(AddRoles))]
        public async Task<IActionResult> AddRoles(int id)
        {
            var cancellationToken = _httpContextAccessor.HttpContext?.RequestAborted ?? CancellationToken.None;
            await _roleService.AddRolesAsync(cancellationToken);

            return Ok();
        }
    }
}
