using Microsoft.EntityFrameworkCore;
using MyArt.DataAccess.Contracts;
using MyArt.DataAccess.Contracts.Providers;
using MyArt.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace MyArt.DataAccess.Providers
{
    public class BoardProvider : BaseProvider<Board>, IBoardProvider
    {
        private readonly DbSet<Board> _boardEntities;

        public BoardProvider(IDataProvider dataProvider) : base(dataProvider)
        {
            _boardEntities = dataProvider.GetSet<Board>();
        }

        public async override Task<Board> GetItemByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _boardEntities.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }
    }
}
