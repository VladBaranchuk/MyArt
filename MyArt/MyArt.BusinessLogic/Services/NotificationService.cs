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
                UserId = user.Id,
                Message = $"Пользователь с ником {currentUser.Alias} оценил вашу работу",
                CurrentUserId = currentUserId
            };

            return notification;
        }

        public async Task<NotificationViewModel> AddCommentNotificationAsync(int artId, CancellationToken cancellationToken)
        {
            var currentUserId = _currentUserService.GetUserIdByHttpContext(cancellationToken);

            var currentUser = await _userProvider.GetItemByIdAsync(currentUserId, cancellationToken);
            var user = await _userProvider.GetItemByArtIdAsync(artId, cancellationToken);

            var notification = new NotificationViewModel()
            {
                UserId = user.Id,
                Message = $"Пользователь с ником {currentUser.Alias} прокомментировал вашу работу",
                CurrentUserId = currentUserId
            };

            return notification;
        }
    }
}
