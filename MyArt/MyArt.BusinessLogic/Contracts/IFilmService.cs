using MyArt.API.ViewModels;

namespace MyArt.BusinessLogic.Contracts
{
    public interface IFilmService
    {
        Task<FilmViewModel> GetFilmByIdAsync(int id, CancellationToken cancellationToken);
        Task AddLikeByIdAsync(int filmId, CancellationToken cancellationToken);
        Task AddCommentByIdAsync(CreateFilmCommentViewModel comment, CancellationToken cancellationToken);
        Task<FilmViewModel> AddFilmAsync(CreateFilmViewModel createFilmVM, CancellationToken cancellationToken);

    }
}
