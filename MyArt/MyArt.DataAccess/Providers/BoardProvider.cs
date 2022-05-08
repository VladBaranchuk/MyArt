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
    public class BoardProvider : BaseProvider<Board>, IBoardProvider
    {
        private readonly IMapper _mapper;
        private readonly DbSet<Board> _boardEntities;

        public BoardProvider(IDataProvider dataProvider, IMapper mapper) : base(dataProvider)
        {
            _mapper = mapper;
            _boardEntities = dataProvider.GetSet<Board>();
        }

        public async Task<List<ShortBoardViewModel>> GetAllItemsAsync(int page, int size, CancellationToken cancellationToken)
        {
            var query = _boardEntities
                .OrderBy(x => x.Id)
                .Skip(page * size)
                .Take(size)
                .Select(x => new ShortBoardViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Alias = x.User.Alias,
                    FirstId = x.ArtToBoards.FirstOrDefault().ArtId
                });

            return await _mapper.ProjectTo<ShortBoardViewModel>(query).ToListAsync(cancellationToken);
        }

        public async override Task<Board> GetItemByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _boardEntities.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }
    }
}
