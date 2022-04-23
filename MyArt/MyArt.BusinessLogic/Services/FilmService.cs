using AutoMapper;
using MyArt.API.ViewModels;
using MyArt.BusinessLogic.Contracts;
using MyArt.DataAccess.Contracts;
using MyArt.DataAccess.Contracts.Providers;
using MyArt.DataAccess.Contracts.Repositories;
using MyArt.Domain.Entities;

namespace MyArt.BusinessLogic.Services
{
    public class FilmService : IFilmService
    {
        private readonly IDataContext _db;
        private readonly IFilmProvider _filmProvider;
        private readonly IFilmRepository _filmRepository;
        private readonly ICurrentUserService _currentUserService;
        private readonly IMapper _mapper;

        public FilmService(
            IDataContext db,
            IFilmRepository filmRepository,
            IFilmProvider filmProvider,
            ICurrentUserService currentUserService,
            IMapper mapper)
        {
            _db = db;
            _filmProvider = filmProvider;
            _currentUserService = currentUserService;
            _filmRepository = filmRepository;
            _mapper = mapper;
        }

        public async Task<FilmViewModel> GetFilmById(int filmId, CancellationToken cancellationToken)
        {
            var film = await _filmProvider.GetItemByIdAsync(filmId, cancellationToken);
            var likesCount = await _filmProvider.GetLikesCountByIdAsync(filmId, cancellationToken);
            var commentsCount = await _filmProvider.GetCommentsCountByIdAsync(filmId, cancellationToken);
            var comments = await _filmProvider.GetCommentsByIdAsync(filmId, cancellationToken);

            var filmViewModel = new FilmViewModel()
            {
                Id = film.Id,
                Name = film.Name,
                Description = film.Description,
                Price = film.Price,
                ReleaseDate = film.ReleaseDate,
                Country = film.Country,
                Duration = film.Duration,
                Producer = film.Producer,
                ShareCount = film.ShareCount,
                LikesCount = likesCount,
                CommentsCount = commentsCount,
                Comments = comments
            };

            return filmViewModel;  
        }
        public async Task SetLikeById(int filmId, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.GetUserIdByHttpContext(cancellationToken);

            var hasLike = await _filmProvider.HasLikedFilmByIdAsync(userId, filmId, cancellationToken);

            var like = new LikeFilms()
            {
                UserId = userId,
                FilmId = filmId
            };

            if (hasLike)
            {
                await _filmRepository.RemoveLike(like, cancellationToken);
            }
            else
            {
                await _filmRepository.SetLike(like, cancellationToken);
            }

            await _db.SaveChangesAsync(cancellationToken);
        }
    }
}
