
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
        Task<CabinetViewModel> GetCabinetAsync(CancellationToken cancellationToken);
        Task<byte[]> GetAvatarAsync(int userId, CancellationToken cancellationToken);
        Task UpdateAvatarAsync(UpdateAvatarViewModel avatarVM, CancellationToken cancellationToken);
        Task<AccountViewModel> GetAccountAsync(string alias, CancellationToken cancellationToken);
        Task<List<AuthorViewModel>> GetAllAuthorsAsync(int page, int size, CancellationToken cancellationToken);
        Task<List<AuthorViewModel>> GetAllByAuthorsFilterAsync(AuthorFilterViewModel filter, int page, int size, CancellationToken cancellationToken);
    }
}
