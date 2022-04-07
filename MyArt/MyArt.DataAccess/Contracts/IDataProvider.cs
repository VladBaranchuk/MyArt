using Microsoft.EntityFrameworkCore;

namespace MyArt.DataAccess.Contracts
{
    public interface IDataProvider
    {
        DbSet<TEntity> GetSet<TEntity>() where TEntity : class;
    }
}
