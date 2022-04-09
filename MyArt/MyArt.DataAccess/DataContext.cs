using MyArt.DataAccess.Contracts;
using System.Threading;
using System.Threading.Tasks;

namespace MyArt.DataAccess
{
    public class DataContext : IDataContext
    {
        private readonly AppDbContext _dbContext;
        public DataContext(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
