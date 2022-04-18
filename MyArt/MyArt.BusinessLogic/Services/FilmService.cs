using AutoMapper;
using MyArt.API.ViewModels;
using MyArt.BusinessLogic.Contracts;
using MyArt.DataAccess.Contracts.Providers;
using MyArt.DataAccess.Contracts.Repositories;
using MyArt.Domain.Entities;

namespace MyArt.BusinessLogic.Services
{
    public class FilmService : IFilmService
    {
        private readonly IFilmProvider _filmProvider;
        private readonly IFilmRepository _filmRepository;
        private readonly IMapper _mapper;

        public FilmService(
            IFilmRepository filmRepository,
            IFilmProvider filmProvider,
            IMapper mapper)
        {
            _filmProvider = filmProvider;
            _filmRepository = filmRepository;
            _mapper = mapper;
        }

        public async Task<FilmsDetailedInfoViewModel> GetFilmsDetailedInfoById(int id, CancellationToken cancellationToken)
        {
            var film = await _filmProvider.GetItemByIdAsync(id, cancellationToken);

            var filmViewModel = _mapper.Map<Film, FilmsDetailedInfoViewModel>(film);

            return filmViewModel;  
        }
    }
}
