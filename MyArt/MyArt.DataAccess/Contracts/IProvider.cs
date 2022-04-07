using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MyArt.DataAccess.Contracts
{
    interface IProvider<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetAllAsync(int page, int size, CancellationToken cancellation);
        Task<TEntity> GetItemByIdAsync(int id, CancellationToken cancellationToken);
    }
}
