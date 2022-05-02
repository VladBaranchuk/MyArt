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
    public class ArtService : IArtService
    {
        private readonly IDataContext _db;
        private readonly IArtProvider _artProvider;
        private readonly IArtRepository _artRepository;
        private readonly ICommentRepository _commentRepository;
        private readonly ICurrentUserService _currentUserService;
        private readonly IUserService _userService;
        private readonly IColorService _colorService;
        private readonly IMapper _mapper;

        public ArtService(
            IDataContext db,
            IArtRepository artRepository,
            ICommentRepository commentRepository,
            IColorService colorService,
            IArtProvider artProvider,
            IUserService userService,
            ICurrentUserService currentUserService,
            IMapper mapper)
        {
            _db = db;
            _userService = userService;
            _artProvider = artProvider;
            _colorService = colorService;
            _commentRepository = commentRepository;
            _currentUserService = currentUserService;
            _artRepository = artRepository;
            _mapper = mapper;
        }

        public async Task AddCommentByIdAsync(CreateCommentViewModel comment, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.GetUserIdByHttpContext(cancellationToken);

            var newComment = new Comment()
            {
                Text = comment.Text,
                Date = DateTime.Now,
                ArtComments = new List<ArtComments>()
            };

            await _commentRepository.CreateAsync(newComment, cancellationToken);

            var artComments = new ArtComments()
            {
                UserId = userId,
                ArtId = comment.Id,
                CommentId = newComment.Id
            };

            await _artRepository.AddCommentAsync(artComments, cancellationToken);

            newComment.ArtComments.Add(artComments);

            await _db.SaveChangesAsync(cancellationToken);
        }
        public async Task AddLikeByIdAsync(int artId, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.GetUserIdByHttpContext(cancellationToken);

            var hasLiked = await _artProvider.HasLikedArtByIdAsync(userId, artId, cancellationToken);

            var like = new LikeArts()
            {
                UserId = userId,
                ArtId = artId
            };

            if (hasLiked)
            {
                await _artRepository.RemoveLikeAsync(like, cancellationToken);
            }
            else
            {
                await _artRepository.AddLikeAsync(like, cancellationToken);
            }

            await _db.SaveChangesAsync(cancellationToken);
        }
        public async Task<ArtViewModel> GetArtByIdAsync(int artId, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.GetUserIdByHttpContext(cancellationToken);

            var alias = await _userService.GetAliasByIdAsync(userId, cancellationToken);
            var art = await _artProvider.GetItemByIdAsync(artId, cancellationToken);
            var likesCount = await _artProvider.GetLikesCountByIdAsync(artId, cancellationToken);
            var commentsCount = await _artProvider.GetCommentsCountByIdAsync(artId, cancellationToken);
            var comments = await _artProvider.GetCommentsByIdAsync(artId, cancellationToken);
            var hasLiked = await _artProvider.HasLikedArtByIdAsync(userId, artId, cancellationToken);
            var arts = await _artProvider.GetAllUserItemsAsync(userId, 0, 10, cancellationToken);

            var artViewModel = new ArtViewModel()
            {
                Id = art.Id,
                Alias = alias,
                Name = art.Name,
                BrightColor = art.BrightColor,
                DarkColor = art.DarkColor,
                MutedColor = art.MutedColor,
                Price = art.Price,
                ShareCount = art.ShareCount,
                Month = art.Month.ToString(),
                Year = art.Year,
                SellingAvailability = (int)art.SellingAvailability,
                Visible = (int)art.Visible,
                Moderation = (int)art.Moderation,
                Type = (int)art.Type,
                LikesCount = likesCount,
                CommentsCount = commentsCount,
                HasLiked = hasLiked,
                Arts = arts,
                Comments = comments
            };

            return artViewModel;
        }
        public async Task<List<ShortArtViewModel>> GetAllArtsAsync(int page, int size, CancellationToken cancellationToken)
        {
            var arts = await _artProvider.GetAllItemsAsync(page, size, cancellationToken);

            return arts;
        }
        public async Task<List<ShortArtViewModel>> GetAllUserArtsAsync(int page, int size, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.GetUserIdByHttpContext(cancellationToken);

            var arts = await _artProvider.GetAllUserItemsAsync(userId, page, size, cancellationToken);

            return arts;
        }
        public async Task AddArtAsync(CreateArtViewModel createArtVM, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.GetUserIdByHttpContext(cancellationToken);

            byte[] artData = null;
            using (var binaryReader = new BinaryReader(createArtVM.Image.OpenReadStream()))
            {
                artData = binaryReader.ReadBytes((int)createArtVM.Image.Length);
            }

            var colors = _colorService.GetColorPalette(createArtVM.Image);


            Art art = new Art() {
                Name = createArtVM.Name,
                BrightColor = colors[0],
                MutedColor = colors[1],
                DarkColor = colors[2],
                ShareCount = 0,
                Price = createArtVM.Price,
                Month = (EMonth)createArtVM.Month,
                Year = createArtVM.Year,
                SellingAvailability = ESellingAvailability.Available,
                Visible = EVisible.IsVisible,
                Moderation = EModeration.NotModerated,
                Type = (EType)createArtVM.Type,
                Date = DateTime.Now,
                Data = artData,
                UserId = userId
            };

            await _artRepository.CreateAsync(art, cancellationToken);
            await _db.SaveChangesAsync(cancellationToken);
        }
        public async Task<byte[]> GetImageAsync(int artId, CancellationToken cancellationToken)
        {
            var bytes = await _artProvider.GetImageAsync(artId, cancellationToken);

            return bytes;
        }
    }
}
