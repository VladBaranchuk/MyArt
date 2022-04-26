using MyArt.API.ViewModels;

namespace MyArt.BusinessLogic.Contracts
{
    public interface IArtService
    {
        Task<ArtViewModel> GetArtByIdAsync(int artId, CancellationToken cancellationToken);
        Task AddLikeByIdAsync(int artId, CancellationToken cancellationToken);
        Task AddCommentByIdAsync(CreateCommentViewModel comment, CancellationToken cancellationToken);
        Task<ArtViewModel> AddArtAsync(CreateArtViewModel createArtVM, CancellationToken cancellationToken);
        Task<List<ShortArtViewModel>> GetAllArtsAsync(int page, int size, CancellationToken cancellationToken);
        Task UploadArtAsync(CreateArtViewModel createArtVM, CancellationToken cancellationToken);
    }
}
