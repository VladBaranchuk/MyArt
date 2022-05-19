using MyArt.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace MyArt.DataAccess.Contracts.Providers
{
    public interface IArtFormProvider : IProvider<ArtForm>
    {
        Task<int> GetIdByItemAsync(string name, CancellationToken cancellationToken);
    }
}
