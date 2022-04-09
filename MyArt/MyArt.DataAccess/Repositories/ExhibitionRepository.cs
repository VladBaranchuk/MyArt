using MyArt.DataAccess.Contracts;
using MyArt.DataAccess.Contracts.Repositories;
using MyArt.Domain.Entities;

namespace MyArt.DataAccess.Repositories
{
    public class ExhibitionRepository : BaseRepository<Exhibition>, IExhibitionRepository
    {
        public ExhibitionRepository(IDataProvider dataProvider) : base(dataProvider)
        {
        }
    }
}
