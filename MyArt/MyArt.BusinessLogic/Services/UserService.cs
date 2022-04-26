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
        private readonly ICurrentUserService _currentUserService;
        private readonly IMapper _mapper;

        public UserService(
            IDataContext context,
            IUserProvider userProvider,
            IUserRepository userRepository,
            ICurrentUserService currentUserService,
            IJwtService jwtService,
            IMapper mapper)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _userProvider = userProvider;
            _currentUserService = currentUserService;
            _jwtService = jwtService;
            _db = context;
        }

        public async Task<HeaderUserInfoViewModel> GetHeaderUserInfoAsync(CancellationToken cancellationToken)
        {
            var userId = _currentUserService.GetUserIdByHttpContext(cancellationToken);

            var user = await _userProvider.GetItemByIdAsync(userId, cancellationToken);
            var paintingsCount = await _userProvider.GetPaintingsCountAsync(userId, cancellationToken);
            var photosCount = await _userProvider.GetPhotosCountAsync(userId, cancellationToken);
            var sculpturesCount = await _userProvider.GetSculpturesCountAsync(userId, cancellationToken);

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

            if (user == null)
            {
                throw new ApplicationException($"User with id {infoVM.Id} not found");
            }

            user.FirstName = infoVM.FirstName;
            user.LastName = infoVM.LastName;
            user.Description = infoVM.Description;

            await _userRepository.UpdateAsync(user, cancellationToken);
            await _db.SaveChangesAsync(cancellationToken);

            var updatePublicUserInfoViewModel = _mapper.Map<User, UpdatePublicUserInfoViewModel>(user);

            return updatePublicUserInfoViewModel;
        }
    }
}
