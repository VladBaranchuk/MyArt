using MyArt.DataAccess.Contracts;
using MyArt.DataAccess.Contracts.Repositories;
using MyArt.Domain.Entities;

namespace MyArt.DataAccess.Repositories
{
    public class ArtFormRepository : BaseRepository<ArtForm>, IArtFormRepository
    {
        public ArtFormRepository(IDataProvider dataProvider) : base(dataProvider)
        {
        }
    }
}
