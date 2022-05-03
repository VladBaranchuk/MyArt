using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyArt.API.ViewModels;
using MyArt.DataAccess.Contracts;
using MyArt.DataAccess.Contracts.Providers;
using MyArt.Domain.Entities;
using MyArt.Domain.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MyArt.DataAccess.Providers
{
    public class ArtProvider : BaseProvider<Art>, IArtProvider
    {
        private readonly DbSet<Art> _artEntities;
        private readonly DbSet <LikeArts>_likeArtsEntities;
        private readonly DbSet<ArtComments> _artCommentsEntities;
        private readonly DbSet<Comment> _commentEntities;
        private readonly IMapper _mapper;

        public ArtProvider(IDataProvider dataProvider, IMapper mapper) : base(dataProvider)
        {
            _mapper = mapper;
            _commentEntities = dataProvider.GetSet<Comment>();
            _artEntities = dataProvider.GetSet<Art>();
            _likeArtsEntities = dataProvider.GetSet<LikeArts>();
            _artCommentsEntities = dataProvider.GetSet<ArtComments>();
        }

        public async Task<List<CommentViewModel>> GetCommentsByIdAsync(int id, CancellationToken cancellationToken)
        {
            var commentIds = _artCommentsEntities
               .Where(x => x.ArtId == id)
               .Select(x => x.CommentId);

            var query = _commentEntities
                .Where(x => commentIds.Contains(x.Id))
                .Select(x => new CommentViewModel()
                {
                    Id = x.Id,
                    Text = x.Text,
                    Date = x.Date,
                    Alias = x.ArtComments.Where(x => x.ArtId == id).Select(x => x.User.Alias).FirstOrDefault()
                });

            var result = await _mapper.ProjectTo<CommentViewModel>(query).ToListAsync(cancellationToken);
            return result;
        }
        public async Task<int> GetCommentsCountByIdAsync(int id, CancellationToken cancellationToken)
        {
            var count = await _artCommentsEntities.Select(x => x.ArtId == id).CountAsync(cancellationToken);
            return count;
        }
        public async override Task<Art> GetItemByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _artEntities.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }
        public async Task<List<ShortArtViewModel>> GetAllItemsAsync(int page, int size, CancellationToken cancellationToken)
        {
            var query = _artEntities
                .OrderBy(x => x.Id)
                .Skip(page * size)
                .Take(size)
                .Select(x => new ShortArtViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Year = x.Year,
                    Alias = x.User.Alias,
                });

            return await _mapper.ProjectTo<ShortArtViewModel>(query).ToListAsync(cancellationToken);
        }
        public async Task<int> GetLikesCountByIdAsync(int id, CancellationToken cancellationToken)
        {
            var count = await _likeArtsEntities.Select(x => x.ArtId == id).CountAsync(cancellationToken);
            return count;
        }
        public async Task<bool> HasLikedArtByIdAsync(int userId, int artId, CancellationToken cancellationToken)
        {
            var hasLiked = await _likeArtsEntities
               .Where(x => x.ArtId == artId)
               .AnyAsync(x => x.UserId == userId, cancellationToken);

            return hasLiked;
        }
        public async Task<List<ShortArtViewModel>> GetAllUserItemsAsync(int userId, int page, int size, CancellationToken cancellationToken)
        {
            var query = _artEntities
                .Where(x => x.UserId == userId)
                .OrderBy(x => x.Id)
                .Skip(page * size)
                .Take(size)
                .Select(x => new ShortArtViewModel()
                {
                    Id = x.Id,
                    Alias = x.User.Alias,
                });

            return await _mapper.ProjectTo<ShortArtViewModel>(query).ToListAsync(cancellationToken);
        }
        public async Task<List<ShortArtViewModel>> GetAllNewUserItemsAsync(int userId, int page, int size, CancellationToken cancellationToken)
        {
            var query = _artEntities
                .Where(x => x.UserId == userId)
                .OrderByDescending(x => x.Date)
                .Skip(page * size)
                .Take(size)
                .Select(x => new ShortArtViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Year = x.Year,
                    Alias = x.User.Alias,
                });

            return await _mapper.ProjectTo<ShortArtViewModel>(query).ToListAsync(cancellationToken);
        }
        public async Task<byte[]> GetImageAsync(int artId, CancellationToken cancellationToken)
        {
            var query = await _artEntities
                .Where(x => x.Id == artId)
                .Select(x => x.Data)
                .FirstOrDefaultAsync(cancellationToken);

            return query;
        }
        public Task<int> GetPaintingsCountAsync(int id, CancellationToken token)
        {
            return _artEntities
                .Where(x => x.UserId == id)
                .Select(x => x.Type == EType.Picture)
                .CountAsync(token);
        }
        public Task<int> GetPhotosCountAsync(int id, CancellationToken token)
        {
            return _artEntities
                .Where(x => x.UserId == id)
                .Select(x => x.Type == EType.Photo)
                .CountAsync(token);
        }
        public Task<int> GetSculpturesCountAsync(int id, CancellationToken token)
        {
            return _artEntities
                .Where(x => x.UserId == id)
                .Select(x => x.Type == EType.Sculpture)
                .CountAsync(token);
        }
    }
}
