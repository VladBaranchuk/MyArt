using System.Threading;
using System.Threading.Tasks;

namespace MyArt.DataAccess.Contracts
{
    public interface IDataContext
    {
        public Task<int> SaveChangesAsync(CancellationToken token);
    }
}
