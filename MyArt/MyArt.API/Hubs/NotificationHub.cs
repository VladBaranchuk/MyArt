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

            await Clients.User(result.UserId).SendAsync("Like", result.Message);
            //await Clients.All.SendAsync("Like", result.Message);
        }

        public override async Task OnConnectedAsync()
        {
            await Clients.Users(new string[] {"1", "3"}).SendAsync("Notify", $"{Context.User?.Identity?.Name} вошел");
            await base.OnConnectedAsync();
        }
        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await Clients.Users(new string[] { "1", "3" }).SendAsync("Notify", $"{Context.User?.Identity?.Name} ушел");
            await base.OnDisconnectedAsync(exception);
        }


    }
}
