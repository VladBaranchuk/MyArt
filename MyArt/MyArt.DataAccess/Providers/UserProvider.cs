using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyArt.API.ViewModels;
using MyArt.DataAccess.Contracts;
using MyArt.DataAccess.Contracts.Providers;
using MyArt.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MyArt.DataAccess.Providers
{
    public class UserProvider : BaseProvider<User>, IUserProvider
    {
        private readonly DbSet<User> _userEntities;
        private readonly DbSet<Art> _artEntities;
        private readonly IMapper _mapper;

        public UserProvider(IDataProvider dataProvider, IMapper mapper) : base(dataProvider)
        {
            _userEntities = dataProvider.GetSet<User>();
            _artEntities = dataProvider.GetSet<Art>();
            _mapper = mapper;
        }

        public async Task<List<AuthorViewModel>> GetAllItemsAsync(int page, int size, CancellationToken cancellationToken)
        {
            var query = _userEntities
                .OrderBy(x => x.Id)
                .Skip(page * size)
                .Take(size)
                .Select(x => new AuthorViewModel()
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Alias = x.Alias
                });

            return await _mapper.ProjectTo<AuthorViewModel>(query).ToListAsync(cancellationToken);
        }
        public override async Task<User> GetItemByIdAsync(int id, CancellationToken token)
        {
            var query = await _userEntities
                .TagWith("----------GetItemByIdAsync----------")
                .Include(x => x.RoleToUsers)
                .ThenInclude(x => x.Role)
                .FirstOrDefaultAsync(x => x.Id == id, token);

            return query;
        }
        public async Task<User> GetItemByAliasAsync(string alias, CancellationToken token)
        {
            return await _userEntities.Include(x => x.RoleToUsers).ThenInclude(x => x.Role).FirstOrDefaultAsync(x => x.Alias == alias, token);
        }
        public async Task<User> GetItemByEmailAsync(string email, CancellationToken token)
        {
            return await _userEntities.Include(x => x.RoleToUsers).ThenInclude(x => x.Role).Where(x => x.Email == email).FirstOrDefaultAsync(token);
        } 
        public async Task<User> GetItemByArtIdAsync(int artId, CancellationToken token)
        {
            var result = await _artEntities.Where(x => x.Id == artId).Select(x => x.User).FirstOrDefaultAsync(token);

            return result;
        }
        public async Task<byte[]> GetAvatarAsync(int userId, CancellationToken cancellationToken)
        {
            var query = await _userEntities
                .Where(x => x.Id == userId)
                .Select(x => x.Data)
                .FirstOrDefaultAsync(cancellationToken);

            return query;
        }
        public Task<bool> HasAnyByEmailAsync(string email, CancellationToken token)
        {
            return _userEntities.AnyAsync(x => x.Email == email, token);
        }
        public async Task<List<AuthorViewModel>> GetAllByAuthorsFilterAsync(AuthorFilterViewModel filter, int page, int size, CancellationToken cancellationToken)
        {
            var query = _userEntities.AsQueryable();

            if (filter.Type.HasValue && filter.Type.Value == 0)
            {
                query = query.OrderBy(x => x.FirstName);
            }

            if (filter.Type.HasValue && filter.Type.Value == 1)
            {
                query = query.OrderByDescending(x => x.FirstName);
            }

            if (!String.IsNullOrEmpty(filter.searchString))
            {
                query = query.Where(x => (x.FirstName + " " + x.LastName).Contains(filter.searchString));
            }

            var resultQuery = query
                .Skip(page * size)
                .Take(size)
                .Select(x => new AuthorViewModel()
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Alias = x.Alias
                });

            var result = await _mapper.ProjectTo<AuthorViewModel>(resultQuery).ToListAsync(cancellationToken);

            return result;
        }
    }
}
