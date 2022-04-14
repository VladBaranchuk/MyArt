using MyArt.API.ViewModels;

namespace MyArt.BusinessLogic.Contracts
{
    public interface ICurrentUserService
    {
        Task<ShortUserInfoViewModel> GetShortCurrentUserInfoAsync(CancellationToken cancellationToken);
        int GetUserIdByHttpContext(CancellationToken cancellationToken);
    }
}
