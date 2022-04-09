using MyArt.DataAccess.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace MyArt.DataAccess.Providers
{
    public abstract class BaseProvider<TEntity> where TEntity : class
    {
        private readonly DbSet<TEntity> _entities;

        public BaseProvider(IDataProvider dataProvider)
        {
            _entities = dataProvider.GetSet<TEntity>();
        }
        public virtual Task<List<TEntity>> GetAllAsync(int page, int size, CancellationToken cancellationToken)
        {
            return _entities.Skip(page * size).Take(size).ToListAsync(cancellationToken);
        }
        public abstract Task<TEntity> GetItemByIdAsync(int id, CancellationToken cancellationToken);
    }
}
