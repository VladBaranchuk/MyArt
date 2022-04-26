
using MyArt.API.ViewModels;

namespace MyArt.BusinessLogic.Contracts
{
    public interface IUserService
    {
        Task<string> GetAliasByIdAsync(int id, CancellationToken cancellationToken);
        Task<HeaderUserInfoViewModel> GetHeaderUserInfoAsync(CancellationToken cancellationToken);
        Task<string> AuthenticateAsync(AuthenticationViewModel authVM, CancellationToken cancellationToken);
        Task RegisterAsync(RegisterViewModel registerVM, CancellationToken cancellationToken);
        Task<UserViewModel> GetUserByIdAsync(int id, CancellationToken cancellationToken);
        Task<bool> HasAnyByEmailAsync(string email, CancellationToken cancellationToken);
        Task<UpdatePublicUserInfoViewModel> UpdatePublicUserInfoAsync(UpdatePublicUserInfoViewModel infoVM, CancellationToken cancellationToken);
    }
}
