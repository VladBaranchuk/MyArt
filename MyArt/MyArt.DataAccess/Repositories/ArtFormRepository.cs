using Microsoft.EntityFrameworkCore;
using MyArt.DataAccess.Contracts;
using MyArt.DataAccess.Contracts.Repositories;
using MyArt.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace MyArt.DataAccess.Repositories
{
    public class ArtFormRepository : BaseRepository<ArtForm>, IArtFormRepository
    {
        private readonly DbSet<ArtForm> _artFormEntities;
        private readonly DbSet<ArtFormToArt> _artFormToArtEntities;

        public ArtFormRepository(IDataProvider dataProvider) : base(dataProvider)
        {
            _artFormEntities = dataProvider.GetSet<ArtForm>();
            _artFormToArtEntities = dataProvider.GetSet<ArtFormToArt>();
        }

        public Task AddArtFormsAsync(CancellationToken cancellationToken)
        {
            _artFormEntities.Add(new ArtForm() { Name = "Пейзаж" });
            _artFormEntities.Add(new ArtForm() { Name = "Авангард" });
            _artFormEntities.Add(new ArtForm() { Name = "Марина" });
            _artFormEntities.Add(new ArtForm() { Name = "Портрет" });
            _artFormEntities.Add(new ArtForm() { Name = "Абстракционизм" });
            _artFormEntities.Add(new ArtForm() { Name = "Супрематизм" });
            return Task.CompletedTask;
        }

        public Task AddArtAndArtFormAsync(Art art, int artFormId, CancellationToken cancellationToken)
        {
            _artFormToArtEntities.Add(new ArtFormToArt() { Art = art, ArtFormId = artFormId });
            return Task.CompletedTask;
        }
    }
}
