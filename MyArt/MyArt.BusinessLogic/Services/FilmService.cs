using AutoMapper;
using MyArt.API.ViewModels;
using MyArt.BusinessLogic.Contracts;
using MyArt.DataAccess.Contracts;
using MyArt.DataAccess.Contracts.Providers;
using MyArt.DataAccess.Contracts.Repositories;
using MyArt.Domain.Entities;
using MyArt.Domain.Enums;

namespace MyArt.BusinessLogic.Services
{
    public class FilmService : IFilmService
    {
        private readonly IDataContext _db;
        private readonly IFilmProvider _filmProvider;
        private readonly IFilmRepository _filmRepository;
        private readonly ICommentRepository _commentRepository;
        private readonly ICurrentUserService _currentUserService;
        private readonly IMapper _mapper;

        public FilmService(
            IDataContext db,
            IFilmRepository filmRepository,
            ICommentRepository commentRepository,
            IFilmProvider filmProvider,
            ICurrentUserService currentUserService,
            IMapper mapper)
        {
            _db = db;
            _filmProvider = filmProvider;
            _commentRepository = commentRepository;
            _currentUserService = currentUserService;
            _filmRepository = filmRepository;
            _mapper = mapper;
        }

        public async Task<FilmViewModel> GetFilmByIdAsync(int filmId, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.GetUserIdByHttpContext(cancellationToken);

            var film = await _filmProvider.GetItemByIdAsync(filmId, cancellationToken);
            var likesCount = await _filmProvider.GetLikesCountByIdAsync(filmId, cancellationToken);
            var commentsCount = await _filmProvider.GetCommentsCountByIdAsync(filmId, cancellationToken);
            var comments = await _filmProvider.GetCommentsByIdAsync(filmId, cancellationToken);
            var hasLiked = await _filmProvider.HasLikedFilmByIdAsync(userId, filmId, cancellationToken);

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
                HasLiked = hasLiked,
                Comments = comments
            };

            return filmViewModel;  
        }
        public async Task<FilmViewModel> AddFilmAsync(CreateFilmViewModel createFilmVM, CancellationToken cancellationToken)
        {
            var newFilm = new Film()
            {
                Name = createFilmVM.Name,
                Description = createFilmVM?.Description,
                Price = createFilmVM.Price,
                Country = createFilmVM.Country,
                Duration = createFilmVM.Duration,
                Producer = createFilmVM.Producer,
                Visible = (EVisible)createFilmVM.Visible,
                Announcement = (EAnnouncement)createFilmVM.Announcement,
                Release = (ERelease)createFilmVM.Release,
                ReleaseDate = createFilmVM.ReleaseDate
            };

            await _filmRepository.CreateAsync(newFilm, cancellationToken);
            await _db.SaveChangesAsync(cancellationToken);

            var filmVM = _mapper.Map<Film, FilmViewModel>(newFilm);

            return filmVM;
        }
        public async Task AddLikeByIdAsync(int filmId, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.GetUserIdByHttpContext(cancellationToken);

            var hasLiked = await _filmProvider.HasLikedFilmByIdAsync(userId, filmId, cancellationToken);

            var like = new LikeFilms()
            {
                UserId = userId,
                FilmId = filmId
            };

            if (hasLiked)
            {
                await _filmRepository.RemoveLikeAsync(like, cancellationToken);
            }
            else
            {
                await _filmRepository.AddLikeAsync(like, cancellationToken);
            }

            await _db.SaveChangesAsync(cancellationToken);
        }
        public async Task AddCommentByIdAsync(CreateCommentViewModel comment, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.GetUserIdByHttpContext(cancellationToken);

            var newComment = new Comment()
            {
                Text = comment.Text,
                Date = DateTime.Now
            };

            await _commentRepository.CreateAsync(newComment, cancellationToken);

            FilmComments filmComments = new FilmComments()
            {
                UserId = userId,
                FilmId = comment.Id,
                CommentId = newComment.Id
            };

            await _filmRepository.AddCommentAsync(filmComments, cancellationToken);
            await _db.SaveChangesAsync(cancellationToken);
        }
    }
}
