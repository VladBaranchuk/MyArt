using AutoMapper;
using MyArt.BusinessLogic.Contracts;
using MyArt.DataAccess.Contracts;
using MyArt.DataAccess.Contracts.Providers;
using MyArt.DataAccess.Contracts.Repositories;

namespace MyArt.BusinessLogic.Services
{
    public class ArtFormService : IArtFormService
    {
        private readonly IDataContext _db;
        private readonly IArtFormProvider _artFormProvider;
        private readonly IArtFormRepository _artFormRepository;
        private readonly ICurrentUserService _currentUserService;
        private readonly IMapper _mapper;

        public ArtFormService(
            IDataContext dataContext,
            IArtFormProvider artFormProvider,
            IArtFormRepository artFormRepository,
            ICurrentUserService currentUserService,
            IMapper mapper)
        {
            _db = dataContext;
            _artFormProvider = artFormProvider;
            _artFormRepository = artFormRepository;
            _currentUserService = currentUserService;
            _mapper = mapper;
        }
        public async Task AddArtFormsAsync(CancellationToken cancellationToken)
        {
            await _artFormRepository.AddArtFormsAsync(cancellationToken);
            await _db.SaveChangesAsync(cancellationToken);
        }
    }
}
