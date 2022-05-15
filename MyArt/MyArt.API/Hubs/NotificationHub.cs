using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using MyArt.BusinessLogic.Contracts;

namespace MyArt.API.Hubs
{
    public class NotificationHub : Hub 
    {
        private readonly INotificationService _notificationService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public NotificationHub(
            IHttpContextAccessor httpContextAccessor,
            INotificationService notificationService)
        {
            _notificationService = notificationService;
            _httpContextAccessor = httpContextAccessor;
        }

        [Authorize]
        public async Task Like(string artId)
        {
            var cancellationToken = _httpContextAccessor.HttpContext?.RequestAborted ?? CancellationToken.None;
            var result = await _notificationService.AddLikeNotificationAsync(Convert.ToInt32(artId), cancellationToken);

            if(result.CurrentUserId != result.UserId)
            {
                await Clients.User(result.UserId.ToString()).SendAsync("Message", result.Message);
            } 
        }

        [Authorize]
        public async Task Comment(string artId)
        {
            var cancellationToken = _httpContextAccessor.HttpContext?.RequestAborted ?? CancellationToken.None;
            var result = await _notificationService.AddCommentNotificationAsync(Convert.ToInt32(artId), cancellationToken);

            if (result.CurrentUserId != result.UserId)
            {
                await Clients.User(result.UserId.ToString()).SendAsync("Message", result.Message);
            }
        }
    }
}
