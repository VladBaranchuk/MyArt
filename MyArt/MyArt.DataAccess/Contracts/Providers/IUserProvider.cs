using MyArt.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace MyArt.DataAccess.Contracts.Providers
{
    public interface IUserProvider : IProvider<User>
    {
        Task<User> GetItemByEmailAsync(string email, CancellationToken cancellationToken);
        Task<bool> HasAnyByEmailAsync(string email, CancellationToken cancellationToken);
        Task<int> GetPaintingsCountAsync(int id, CancellationToken token);
        Task<int> GetPhotosCountAsync(int id, CancellationToken token);
        Task<int> GetSculpturesCountAsync(int id, CancellationToken token);
    }
}
