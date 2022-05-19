
namespace MyArt.BusinessLogic.Contracts
{
    public interface IArtFormService
    {
        Task AddArtFormsAsync(CancellationToken cancellationToken);
    }
}
