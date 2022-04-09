using MyArt.DataAccess.Contracts;
using MyArt.DataAccess.Contracts.Repositories;
using MyArt.Domain.Entities;

namespace MyArt.DataAccess.Repositories
{
    public class BoardRepository : BaseRepository<Board>, IBoardRepository
    {
        public BoardRepository(IDataProvider dataProvider) : base(dataProvider)
        {
        }
    }
}
