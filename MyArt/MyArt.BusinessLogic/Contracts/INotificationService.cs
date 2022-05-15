

using Microsoft.AspNetCore.SignalR;
using MyArt.API.ViewModels;

namespace MyArt.BusinessLogic.Contracts
{
    public interface INotificationService
    {
        Task<NotificationViewModel> AddLikeNotificationAsync(int artId, CancellationToken cancellationToken);
        Task<NotificationViewModel> AddCommentNotificationAsync(int artId, CancellationToken cancellationToken);
    }
}
