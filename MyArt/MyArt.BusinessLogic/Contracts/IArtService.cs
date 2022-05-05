using MyArt.API.ViewModels;

namespace MyArt.BusinessLogic.Contracts
{
    public interface IArtService
    {
        Task<ArtViewModel> GetArtByIdAsync(int artId, CancellationToken cancellationToken);
        Task AddLikeByIdAsync(int artId, CancellationToken cancellationToken);
        Task<CommentViewModel> AddCommentByIdAsync(CreateCommentViewModel comment, CancellationToken cancellationToken);
        Task<List<ShortArtViewModel>> GetAllArtsAsync(int page, int size, CancellationToken cancellationToken);
        Task AddArtAsync(CreateArtViewModel createArtVM, CancellationToken cancellationToken);
        Task<List<ShortArtViewModel>> GetAllByArtsFilterAsync(ArtFilterViewModel filter, int page, int size, CancellationToken cancellationToken);
        Task<byte[]> GetImageAsync(int artId, CancellationToken cancellationToken);
    }
}
