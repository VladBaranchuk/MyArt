using MyArt.API.ViewModels;
using MyArt.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MyArt.DataAccess.Contracts.Providers
{
    public interface IUserProvider : IProvider<User>
    {
        Task<User> GetItemByEmailAsync(string email, CancellationToken cancellationToken);
        Task<bool> HasAnyByEmailAsync(string email, CancellationToken cancellationToken);
        Task<byte[]> GetAvatarAsync(int userId, CancellationToken cancellationToken);
        Task<User> GetItemByAliasAsync(string alias, CancellationToken token);
        Task<User> GetItemByArtIdAsync(int artId, CancellationToken token);
        Task<List<AuthorViewModel>> GetAllItemsAsync(int page, int size, CancellationToken cancellationToken);
        Task<List<AuthorViewModel>> GetAllByAuthorsFilterAsync(AuthorFilterViewModel filter, int page, int size, CancellationToken cancellationToken);
        Task<int> GetAllCountAsync(CancellationToken cancellationToken);
    }
}
