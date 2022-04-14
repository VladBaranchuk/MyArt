using AutoMapper;
using Microsoft.AspNetCore.Http;
using MyArt.API.ViewModels;
using MyArt.BusinessLogic.Contracts;
using MyArt.DataAccess.Contracts.Providers;
using MyArt.Domain.Entities;

namespace MyArt.BusinessLogic.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IUserProvider _userProvider;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(
            IUserProvider userProvider,
            IHttpContextAccessor httpContextAccessor,
            IMapper mapper)
        {
            _userProvider = userProvider;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public int GetUserIdByHttpContext(CancellationToken cancellationToken)
        {
            int.TryParse(_httpContextAccessor.HttpContext?.User.Identity?.Name, out int UserId);

            return UserId;
        }
        public async Task<ShortUserInfoViewModel> GetShortCurrentUserInfoAsync(CancellationToken cancellationToken)
        {
            var id = GetUserIdByHttpContext(cancellationToken);

            var user = await _userProvider.GetItemByIdAsync(id, cancellationToken);

            var userViewModel = _mapper.Map<User, ShortUserInfoViewModel>(user);

            return userViewModel;
        }
    }
}
