using MyArt.API.ViewModels;

namespace MyArt.BusinessLogic.Contracts
{
    public interface IFilmService
    {
        Task<FilmViewModel> GetFilmByIdAsync(int id, CancellationToken cancellationToken);
        Task AddLikeByIdAsync(int filmId, CancellationToken cancellationToken);
        Task AddCommentByIdAsync(CreateCommentViewModel comment, CancellationToken cancellationToken);
        Task<FilmViewModel> AddFilmAsync(CreateFilmViewModel createFilmVM, CancellationToken cancellationToken);
        Task<List<ShortFilmViewModel>> GetAllFilmsAsync(int page, int size, CancellationToken cancellationToken);

    }
}
