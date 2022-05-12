

using Microsoft.AspNetCore.SignalR;
using MyArt.API.ViewModels;

namespace MyArt.BusinessLogic.Contracts
{
    public interface INotificationService
    {
        Task<NotificationViewModel> AddLikeNotificationAsync(int artId, CancellationToken cancellationToken);
    }
}
