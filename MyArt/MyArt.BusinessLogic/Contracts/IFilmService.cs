using MyArt.API.ViewModels;

namespace MyArt.BusinessLogic.Contracts
{
    public interface IFilmService
    {
        Task<FilmViewModel> GetFilmById(int id, CancellationToken cancellationToken);
        Task SetLikeById(int filmId, CancellationToken cancellationToken);
    }
}
