using MyArt.DataAccess.Contracts;
using MyArt.DataAccess.Contracts.Repositories;
using MyArt.Domain.Entities;

namespace MyArt.DataAccess.Repositories
{
    public class CommentRepository : BaseRepository<Comment>, ICommentRepository
    {
        public CommentRepository(IDataProvider dataProvider) : base(dataProvider)
        {

        }
    }
}
