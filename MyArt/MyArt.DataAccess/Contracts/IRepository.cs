using System.Threading;
using System.Threading.Tasks;

namespace MyArt.DataAccess.Contracts
{
    public interface IRepository<T> where T : class
    {
        Task CreateAsync(T entity, CancellationToken token);
        Task UpdateAsync(T entity, CancellationToken token);
        Task DeleteAsync(T entity, CancellationToken token);
    }
}
