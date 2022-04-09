using MyArt.DataAccess.Contracts;
using MyArt.DataAccess.Contracts.Repositories;
using MyArt.Domain.Entities;

namespace MyArt.DataAccess.Repositories
{
    public class FilmRepository : BaseRepository<Film>, IFilmRepository
    {
        public FilmRepository(IDataProvider dataProvider) : base(dataProvider)
        {
        }
    }
}
