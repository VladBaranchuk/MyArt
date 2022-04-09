using Microsoft.EntityFrameworkCore;
using MyArt.DataAccess.Contracts;

namespace MyArt.DataAccess
{
    public class DataProvider : IDataProvider
    {
        private readonly AppDbContext appDbContext;

        public DataProvider(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public DbSet<T> GetSet<T>() where T : class
        {
            return appDbContext.Set<T>();
        }
    }
}
