using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyArt.API.ViewModels;
using MyArt.DataAccess.Contracts;
using MyArt.DataAccess.Contracts.Providers;
using MyArt.Domain.Entities;
using MyArt.Domain.Enums;
using System;
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
        private readonly DbSet<ArtToBoard> _artToBoardsEntities;
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
            _artToBoardsEntities = dataProvider.GetSet<ArtToBoard>();
        }
        public async Task<List<CommentViewModel>> GetCommentsByIdAsync(int id, CancellationToken cancellationToken)
        {
            var commentIds = _artCommentsEntities
               .Where(x => x.ArtId == id)
               .Select(x => x.CommentId);

            var query = _commentEntities
                .Where(x => commentIds.Contains(x.Id))
                .OrderByDescending(x => x)
                .Select(x => new CommentViewModel()
                {
                    Id = x.Id,
                    UserId = x.ArtComments.Where(x => x.ArtId == id).Select(x => x.User.Id).FirstOrDefault(),
                    Text = x.Text,
                    Date = x.Date.ToString("d"),
                    Alias = x.ArtComments.Where(x => x.ArtId == id).Select(x => x.User.Alias).FirstOrDefault()
                });

            var result = await _mapper.ProjectTo<CommentViewModel>(query).ToListAsync(cancellationToken);
            return result;
        }
        public async Task<int> GetCommentsCountByIdAsync(int id, CancellationToken cancellationToken)
        {
            var count = await _artCommentsEntities.Where(x => x.ArtId == id).CountAsync(cancellationToken);
            return count;
        }
        public async override Task<Art> GetItemByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _artEntities.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }
        public async Task<List<ShortArtViewModel>> GetAllItemsAsync(int page, int size, int type, CancellationToken cancellationToken)
        {
            var query = _artEntities
                .OrderBy(x => x.Id)
                .Skip(page * size)
                .Take(size);

            if (type != 0)
            {
                query = query.Where(x => x.Type == (EType)type);
            }

            var result = query
                .Select(x => new ShortArtViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Year = x.Year,
                    Alias = x.User.Alias,
                    BrightColor = x.BrightColor,
                    MutedColor = x.MutedColor,
                    DarkColor = x.DarkColor
                });

            return await _mapper.ProjectTo<ShortArtViewModel>(result).ToListAsync(cancellationToken);
        }
        public async Task<int> GetLikesCountByIdAsync(int id, CancellationToken cancellationToken)
        {
            var count = await _likeArtsEntities.Where(x => x.ArtId == id).CountAsync(cancellationToken);
            return count;
        }
        public async Task<bool> HasLikedArtByIdAsync(int userId, int artId, CancellationToken cancellationToken)
        {
            var hasLiked = await _likeArtsEntities
               .Where(x => x.ArtId == artId)
               .AnyAsync(x => x.UserId == userId, cancellationToken);

            return hasLiked;
        }
        public async Task<bool> HasOnBoardArtByIdAsync(int userId, int artId, CancellationToken cancellationToken)
        {
            var hasOnBoard = await _artToBoardsEntities
               .Where(x => x.Board.UserId == userId)
               .AnyAsync(x => x.ArtId == artId, cancellationToken);

            return hasOnBoard;
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
                    Name = x.Name,
                    Year = x.Year,
                    Alias = x.User.Alias,
                    BrightColor = x.BrightColor,
                    MutedColor = x.MutedColor,
                    DarkColor = x.DarkColor
                });

            return await _mapper.ProjectTo<ShortArtViewModel>(query).ToListAsync(cancellationToken);
        }
        public async Task<List<ShortArtViewModel>> GetAllBoardItemsAsync(int boardId, int page, int size, CancellationToken cancellationToken)
        {
            var query = _artToBoardsEntities
                .Where(x => x.BoardId == boardId)
                .Select(x=> x.Art)
                .OrderBy(x => x)
                .Skip(page * size)
                .Take(size)
                .Select(x => new ShortArtViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Year = x.Year,
                    Alias = x.User.Alias,
                    BrightColor = x.BrightColor,
                    MutedColor = x.MutedColor,
                    DarkColor = x.DarkColor
                });

            return await _mapper.ProjectTo<ShortArtViewModel>(query).ToListAsync(cancellationToken);
        }
        public async Task<List<ShortArtViewModel>> GetAllByArtsFilterAsync(ArtFilterViewModel filter, int page, int size, CancellationToken cancellationToken)
        {
            var query = _artEntities.AsQueryable();

            if (!String.IsNullOrEmpty(filter.Year))
            {
                query = query.Where(x => Convert.ToInt32(filter.Year) == Convert.ToInt32(x.Year));
            }

            if (filter.MinPrice.HasValue)
            {
                query = query.Where(x => x.Price >= filter.MinPrice.Value);
            }

            if (filter.MaxPrice.HasValue)
            {
                query = query.Where(x => x.Price <= filter.MaxPrice.Value);
            }

            if (filter.Popular)
            {
                query = query.OrderBy(x => x.LikeArts.Count());
            }

            if (filter.Type.HasValue && filter.Type.Value != 0)
            {
                query = query.Where(x => x.Type == (EType)filter.Type.Value);
            }
           

            var resultQuery = query
                .Skip(page * size)
                .Take(size)
                .Select(x => new ShortArtViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Year = x.Year,
                    Alias = x.User.Alias,
                    BrightColor = x.BrightColor,
                    MutedColor = x.MutedColor,
                    DarkColor = x.DarkColor
                });

            var result = await _mapper.ProjectTo<ShortArtViewModel>(resultQuery).ToListAsync(cancellationToken);

            return result;
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
                    BrightColor = x.BrightColor,
                    MutedColor = x.MutedColor,
                    DarkColor = x.DarkColor
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
        public async Task<int> GetPaintingsCountAsync(int id, CancellationToken token)
        {
            return await _artEntities
                .Where(x => x.UserId == id && x.Type == EType.Picture)
                .CountAsync(token);
        }
        public async Task<int> GetPhotosCountAsync(int id, CancellationToken token)
        {
            return await _artEntities
                .Where(x => x.UserId == id && x.Type == EType.Photo)
                .CountAsync(token);
        }
        public async Task<int> GetSculpturesCountAsync(int id, CancellationToken token)
        {
            return await _artEntities
                .Where(x => x.UserId == id && x.Type == EType.Sculpture)
                .CountAsync(token);
        }
        public async Task<bool> HasAnyItemByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _artEntities.AnyAsync(x => x.Id == id, cancellationToken);
        }
    }
}
