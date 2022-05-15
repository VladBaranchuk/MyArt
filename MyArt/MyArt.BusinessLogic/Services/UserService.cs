using AutoMapper;
using MyArt.API.ViewModels;
using MyArt.BusinessLogic.Contracts;
using MyArt.DataAccess.Contracts;
using MyArt.DataAccess.Contracts.Providers;
using MyArt.DataAccess.Contracts.Repositories;
using MyArt.Domain.Entities;

namespace MyArt.BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly IDataContext _db;
        private readonly IJwtService _jwtService;
        private readonly IUserProvider _userProvider;
        private readonly IUserRepository _userRepository;
        private readonly IArtProvider _artProvider;
        private readonly IBoardService _boardService;
        private readonly ICurrentUserService _currentUserService;
        private readonly IMapper _mapper;

        public UserService(
            IDataContext context,
            IUserProvider userProvider,
            IUserRepository userRepository,
            IArtProvider artProvider,
            IBoardService boardService,
            ICurrentUserService currentUserService,
            IJwtService jwtService,
            IMapper mapper)
        {
            _mapper = mapper;
            _artProvider = artProvider;
            _userRepository = userRepository;
            _userProvider = userProvider;
            _currentUserService = currentUserService;
            _jwtService = jwtService;
            _boardService = boardService;
            _db = context;
        }

        public async Task<HeaderUserInfoViewModel> GetHeaderUserInfoAsync(CancellationToken cancellationToken)
        {
            var userId = _currentUserService.GetUserIdByHttpContext(cancellationToken);

            var user = await _userProvider.GetItemByIdAsync(userId, cancellationToken);
            var paintingsCount = await _artProvider.GetPaintingsCountAsync(userId, cancellationToken);
            var photosCount = await _artProvider.GetPhotosCountAsync(userId, cancellationToken);
            var sculpturesCount = await _artProvider.GetSculpturesCountAsync(userId, cancellationToken);

            var headerUserInfoVM = new HeaderUserInfoViewModel()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Alias = user.Alias,
                PaintingsCount = paintingsCount,
                PhotosCount = photosCount,
                SculpturesCount = sculpturesCount
            };

            return headerUserInfoVM;
        }
        public async Task<string> GetAliasByIdAsync(int id, CancellationToken cancellationToken)
        {
            var user = await _userProvider.GetItemByIdAsync(id, cancellationToken);

            var alias = user.Alias;

            return alias;
        }
        public async Task<List<AuthorViewModel>> GetAllAuthorsAsync(int page, int size, CancellationToken cancellationToken)
        {
            var authors = await _userProvider.GetAllItemsAsync(page, size, cancellationToken);

            foreach(var author in authors)
            {
                var arts = await _artProvider.GetAllUserItemsAsync(author.Id, 0, 4, cancellationToken);

                author.Arts = arts;
            }

            return authors;
        }
        public async Task<UserViewModel> GetUserByIdAsync(int id, CancellationToken cancellationToken)
        {
            var user = await _userProvider.GetItemByIdAsync(id, cancellationToken);

            var userViewModel = _mapper.Map<User, UserViewModel>(user);

            return userViewModel;
        }
        public async Task<bool> HasAnyByEmailAsync(string email, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(email))
            {
                return false;
            }
            return await _userProvider.HasAnyByEmailAsync(email, cancellationToken);
        }
        public async Task<CabinetViewModel> GetCabinetAsync(CancellationToken cancellationToken)
        {
            var userId = _currentUserService.GetUserIdByHttpContext(cancellationToken);

            var user = await _userProvider.GetItemByIdAsync(userId, cancellationToken);

            var paintingsCount = await _artProvider.GetPaintingsCountAsync(user.Id, cancellationToken);
            var photosCount = await _artProvider.GetPhotosCountAsync(user.Id, cancellationToken);
            var sculpturesCount = await _artProvider.GetSculpturesCountAsync(user.Id, cancellationToken);
            var arts = await _artProvider.GetAllUserItemsAsync(user.Id, 0, 10, cancellationToken);
            var boards = await _boardService.GetAllUserBoardsAsync(0, 10, cancellationToken);

            var cabinetVM = new CabinetViewModel()
            {
                Id = user.Id,
                Alias = user.Alias,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PaintingsCount = paintingsCount,
                PhotosCount = photosCount,
                SculpturesCount = sculpturesCount,
                Description = user.Description,
                Arts = arts,
                Boards = boards
            };

            return cabinetVM;

        }
        public async Task RegisterAsync(RegisterViewModel registerVM, CancellationToken cancellationToken)
        {
            var user = new User()
            {
                FirstName = registerVM.FirstName,
                LastName = registerVM.LastName,
                Alias = registerVM.Alias,
                PasswordHash = registerVM.Password,
                Email = registerVM.Email
            };

            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash);

            await _userRepository.CreateAsync(user, cancellationToken);
            await _db.SaveChangesAsync(cancellationToken);
        }
        public async Task<string> AuthenticateAsync(AuthenticationViewModel authVM, CancellationToken cancellationToken)
        {
            var jwt = String.Empty;

            var hasAny = await _userProvider.HasAnyByEmailAsync(authVM.Email, cancellationToken);

            if (hasAny)
            {
                var user = await _userProvider.GetItemByEmailAsync(authVM.Email, cancellationToken);

                var userVM = _mapper.Map<User, UserViewModel>(user);

                var verifyPasswordHash = BCrypt.Net.BCrypt.Verify(authVM.Password, userVM.PasswordHash);

                if (verifyPasswordHash)
                {
                    jwt = _jwtService.GenerateToken(userVM);
                }
            }

            return jwt;
        }
        public async Task<UpdatePublicUserInfoViewModel> UpdatePublicUserInfoAsync(UpdatePublicUserInfoViewModel infoVM, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.GetUserIdByHttpContext(cancellationToken);

            var user = await _userProvider.GetItemByIdAsync(userId, cancellationToken);

            user.FirstName = infoVM.FirstName;
            user.LastName = infoVM.LastName;
            user.Description = infoVM.Description;

            await _userRepository.UpdateAsync(user, cancellationToken);
            await _db.SaveChangesAsync(cancellationToken);

            var updatePublicUserInfoViewModel = _mapper.Map<User, UpdatePublicUserInfoViewModel>(user);

            return updatePublicUserInfoViewModel;
        }
        public async Task<byte[]> GetAvatarAsync(int userId, CancellationToken cancellationToken)
        {
            var bytes = await _userProvider.GetAvatarAsync(userId, cancellationToken);

            return bytes;
        }
        public async Task UpdateAvatarAsync(UpdateAvatarViewModel avatarVM, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.GetUserIdByHttpContext(cancellationToken);

            byte[] avatarData = null;
            using (var binaryReader = new BinaryReader(avatarVM.Avatar.OpenReadStream()))
            {
                avatarData = binaryReader.ReadBytes((int)avatarVM.Avatar.Length);
            }

            var user = await _userProvider.GetItemByIdAsync(userId, cancellationToken);

            user.Data = avatarData;

            await _userRepository.UpdateAsync(user, cancellationToken);
            await _db.SaveChangesAsync(cancellationToken);
        }
        public async Task<AccountViewModel> GetAccountAsync(string alias, CancellationToken cancellationToken)
        {
            var user = await _userProvider.GetItemByAliasAsync(alias, cancellationToken);

            var paintingsCount = await _artProvider.GetPaintingsCountAsync(user.Id, cancellationToken);
            var photosCount = await _artProvider.GetPhotosCountAsync(user.Id, cancellationToken);
            var sculpturesCount = await _artProvider.GetSculpturesCountAsync(user.Id, cancellationToken);
            var arts = await _artProvider.GetAllUserItemsAsync(user.Id, 0, 10, cancellationToken);
            var newArts = await _artProvider.GetAllNewUserItemsAsync(user.Id, 0, 12, cancellationToken);

            var accountVM = new AccountViewModel()
            {
                Id = user.Id,
                Alias = user.Alias,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PaintingsCount = paintingsCount,
                PhotosCount = photosCount,
                SculpturesCount = sculpturesCount,
                Description = user.Description,
                NewArts = newArts,
                Arts = arts
            };

            return accountVM;
        }
        public async Task<List<AuthorViewModel>> GetAllByAuthorsFilterAsync(AuthorFilterViewModel filter, int page, int size, CancellationToken cancellationToken)
        {
            var authors = await _userProvider.GetAllByAuthorsFilterAsync(filter, page, size, cancellationToken);

            foreach (var author in authors)
            {
                var arts = await _artProvider.GetAllUserItemsAsync(author.Id, 0, 4, cancellationToken);

                author.Arts = arts;
            }

            return authors;
        }
    }
}
