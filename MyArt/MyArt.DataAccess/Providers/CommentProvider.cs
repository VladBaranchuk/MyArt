using Microsoft.EntityFrameworkCore;
using MyArt.DataAccess.Contracts;
using MyArt.DataAccess.Contracts.Providers;
using MyArt.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace MyArt.DataAccess.Providers
{
    public class CommentProvider : BaseProvider<Comment>, ICommentProvider
    {
        private readonly DbSet<Comment> _commentEntities;

        public CommentProvider(IDataProvider dataProvider) : base(dataProvider)
        {
            _commentEntities = dataProvider.GetSet<Comment>();
        }

        public async override Task<Comment> GetItemByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _commentEntities.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }
    }
}
