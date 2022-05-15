
using MyArt.API.ViewModels;

namespace MyArt.BusinessLogic.Contracts
{
    public interface IHomeService
    {
        Task<HomeViewModel> GetAllAsync(int page, int size, CancellationToken cancellationToken);
    }
}
