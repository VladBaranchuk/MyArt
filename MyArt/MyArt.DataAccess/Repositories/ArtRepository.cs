using MyArt.DataAccess.Contracts;
using MyArt.DataAccess.Contracts.Repositories;
using MyArt.Domain.Entities;

namespace MyArt.DataAccess.Repositories
{
    public class ArtRepository : BaseRepository<Art>, IArtRepository
    {
        public ArtRepository(IDataProvider dataProvider) : base(dataProvider)
        {
        }
    }
}
