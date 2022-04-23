using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyArt.API.ViewModels;
using MyArt.DataAccess.Contracts;
using MyArt.DataAccess.Contracts.Providers;
using MyArt.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MyArt.DataAccess.Providers
{
    public class FilmProvider : BaseProvider<Film>, IFilmProvider
    {
        private readonly DbSet<Film> _filmEntities;
        private readonly DbSet<LikeFilms> _likeFilmsEntities;
        private readonly DbSet<FilmComments> _filmCommentsEntities;
        private readonly IMapper _mapper;

        public FilmProvider(IDataProvider dataProvider, IMapper mapper) : base(dataProvider)
        {
            _mapper = mapper;
            _filmEntities = dataProvider.GetSet<Film>();
            _likeFilmsEntities = dataProvider.GetSet<LikeFilms>();
            _filmCommentsEntities = dataProvider.GetSet<FilmComments>();
        }

        public async override Task<Film> GetItemByIdAsync(int id, CancellationToken cancellationToken)
        {
            var film = await _filmEntities.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            return film;
        }
        public async Task<int> GetLikesCountByIdAsync(int id, CancellationToken cancellationToken)
        {
            var count = await _likeFilmsEntities.Select(x => x.FilmId == id).CountAsync(cancellationToken);
            return count;
        }
        public async Task<int> GetCommentsCountByIdAsync(int id, CancellationToken cancellationToken)
        {
            var count = await _filmCommentsEntities.Select(x => x.FilmId == id).CountAsync(cancellationToken);
            return count;
        }
        public async Task<List<CommentViewModel>> GetCommentsByIdAsync(int id, CancellationToken cancellationToken)
        {
            var query = _filmCommentsEntities
                .Where(x => x.FilmId == id);

            var result = await _mapper.ProjectTo<CommentViewModel>(query).ToListAsync(cancellationToken);
            return result;
        }
        public async Task<bool> HasLikedFilmByIdAsync(int userId, int filmId, CancellationToken cancellationToken)
        {
            var hasLiked = await _likeFilmsEntities
                .Where(x => x.FilmId == filmId)
                .AnyAsync(x => x.UserId == userId, cancellationToken);

            return hasLiked;
        }
    }
}
