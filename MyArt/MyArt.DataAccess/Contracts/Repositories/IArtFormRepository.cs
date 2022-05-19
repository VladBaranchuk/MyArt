using MyArt.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace MyArt.DataAccess.Contracts.Repositories
{
    public interface IArtFormRepository : IRepository<ArtForm>
    {
        Task AddArtFormsAsync(CancellationToken cancellationToken);
        Task AddArtAndArtFormAsync(Art art, int artFormId, CancellationToken cancellationToken);
    }
}
