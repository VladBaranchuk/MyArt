using MyArt.API.ViewModels;

namespace MyArt.BusinessLogic.Contracts
{
    public interface IFilmService
    {
        Task<FilmsDetailedInfoViewModel> GetFilmsDetailedInfoById(int id, CancellationToken cancellationToken);
    }
}
