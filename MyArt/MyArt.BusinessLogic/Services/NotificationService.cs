using MyArt.API.ViewModels;
using MyArt.BusinessLogic.Contracts;
using MyArt.DataAccess.Contracts.Providers;

namespace MyArt.BusinessLogic.Services
{
    public class NotificationService : INotificationService
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IUserProvider _userProvider;
        private readonly IUserService _userService;
        public NotificationService(
            IUserProvider userProvider,
            IUserService userService,
            ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
            _userService = userService;
            _userProvider = userProvider;
        }

        public async Task<NotificationViewModel> AddLikeNotificationAsync(int artId, CancellationToken cancellationToken)
        {
            var currentUserId = _currentUserService.GetUserIdByHttpContext(cancellationToken);

            var currentUser = await _userProvider.GetItemByIdAsync(currentUserId, cancellationToken);
            var user = await _userProvider.GetItemByArtIdAsync(artId, cancellationToken);

            var notification = new NotificationViewModel()
            {
                UserId = user.Id.ToString(),
                Message = $"Пользователь с ником {currentUser.Alias} оценил вашу работу"
            };

            return notification;
        }
    }
}
