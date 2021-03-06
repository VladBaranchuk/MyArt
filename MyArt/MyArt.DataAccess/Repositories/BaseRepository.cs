using Microsoft.EntityFrameworkCore;
using MyArt.DataAccess.Contracts;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MyArt.DataAccess.Repositories
{
    public class BaseRepository<TEntity> where TEntity : class
    {
        private readonly DbSet<TEntity> _entities;

        public BaseRepository(IDataProvider dataProvider)
        {
            _entities = dataProvider.GetSet<TEntity>();
        }

        public virtual Task CreateAsync(TEntity entity, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(entity, nameof(entity));
            _entities.Add(entity);
            return Task.CompletedTask;
        }
        public virtual Task UpdateAsync(TEntity entity, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(entity, nameof(entity));
            _entities.Update(entity);
            return Task.CompletedTask;
        }
        public virtual Task DeleteAsync(TEntity entity, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(entity, nameof(entity));
            _entities.Remove(entity);
            return Task.CompletedTask;
        }
    }
}
