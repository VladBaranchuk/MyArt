using AutoMapper;
using Microsoft.AspNetCore.SignalR;
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
        private readonly IArtFormRepository _artFormRepository;
        private readonly IArtFormProvider _artFormProvider;
        private readonly ICurrentUserService _currentUserService;
        private readonly IUserProvider _userProvider;
        private readonly IUserService _userService;
        private readonly IColorService _colorService;
        private readonly IMapper _mapper;

        public ArtService(
            IDataContext db,
            IArtRepository artRepository,
            ICommentRepository commentRepository,
            IArtFormRepository artFormRepository,
            IArtFormProvider artFormProvider,
            IUserProvider userProvider,
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
            _artFormRepository = artFormRepository;
            _artFormProvider = artFormProvider;
            _userProvider = userProvider;
            _commentRepository = commentRepository;
            _currentUserService = currentUserService;
            _artRepository = artRepository;
            _mapper = mapper;
        }

        public async Task<CommentViewModel> AddCommentByIdAsync(CreateCommentViewModel comment, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.GetUserIdByHttpContext(cancellationToken);
            var user = await _userService.GetUserByIdAsync(userId, cancellationToken);

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

            var comm = _mapper.Map<Comment, CommentViewModel>(newComment);

            comm.UserId = user.Id;
            comm.Alias = user.Alias;

            return comm;
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
        public async Task UpdateShareToArtByIdAsync(int artId, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.GetUserIdByHttpContext(cancellationToken);

            var art = await _artProvider.GetItemByIdAsync(artId, cancellationToken);

            art.ShareCount++;

            await _artRepository.UpdateAsync(art, cancellationToken);
            await _db.SaveChangesAsync(cancellationToken);
        }
        public async Task<ArtViewModel> GetArtByIdAsync(int artId, CancellationToken cancellationToken)
        {
            var currentUserId = _currentUserService.GetUserIdByHttpContext(cancellationToken);

            var user = await _userProvider.GetItemByArtIdAsync(artId, cancellationToken);

            var alias = await _userService.GetAliasByIdAsync(user.Id, cancellationToken);
            var art = await _artProvider.GetItemByIdAsync(artId, cancellationToken);
            var likesCount = await _artProvider.GetLikesCountByIdAsync(artId, cancellationToken);
            var commentsCount = await _artProvider.GetCommentsCountByIdAsync(artId, cancellationToken);
            var comments = await _artProvider.GetCommentsByIdAsync(artId, cancellationToken);
            var hasLiked = await _artProvider.HasLikedArtByIdAsync(currentUserId, artId, cancellationToken);
            var hasOnBoard = await _artProvider.HasOnBoardArtByIdAsync(currentUserId, artId, cancellationToken);
            var arts = await _artProvider.GetAllUserItemsAsync(user.Id, 0, 10, cancellationToken);

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
                HasOnBoard = hasOnBoard,
                Arts = arts,
                Comments = comments
            };

            return artViewModel;
        }
        public async Task<List<ShortArtViewModel>> GetAllArtsAsync(int page, int size, int type, CancellationToken cancellationToken)
        {
            var arts = await _artProvider.GetAllItemsAsync(page, size, type, cancellationToken);

            return arts;
        }
        public async Task<List<ShortArtViewModel>> GetAllByArtsFilterAsync(ArtFilterViewModel filter, int page, int size, CancellationToken cancellationToken)
        {
            var arts = await _artProvider.GetAllByArtsFilterAsync(filter, page, size, cancellationToken);

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

            var artformId = await _artFormProvider.GetIdByItemAsync(createArtVM.ArtForm, cancellationToken);

            byte[] artData = null;
            using (var binaryReader = new BinaryReader(createArtVM.Image.OpenReadStream()))
            {
                artData = binaryReader.ReadBytes((int)createArtVM.Image.Length);
            }

            var colors = _colorService.GetColorPalette(createArtVM.Image, 9);


            Art art = new Art() {
                Name = createArtVM.Name,
                BrightColor = colors.BrightColor,
                MutedColor = colors.MutedColor,
                DarkColor = colors.DarkColor,
                ShareCount = 0,
                Price = createArtVM.Price,
                Month = (EMonth)createArtVM.Month,
                Year = createArtVM.Year,
                SellingAvailability = ESellingAvailability.Available,
                Visible = EVisible.IsVisible,
                Moderation = EModeration.NotModerated,
                Type = (EType)createArtVM.Type,
                Material = createArtVM.Material,
                Size = (int)createArtVM.Size,
                Date = DateTime.Now,
                Data = artData,
                UserId = userId
            };

            await _artRepository.CreateAsync(art, cancellationToken);

            await _artFormRepository.AddArtAndArtFormAsync(art, artformId, cancellationToken);

            await _db.SaveChangesAsync(cancellationToken);
        }
        public async Task<byte[]> GetImageAsync(int artId, CancellationToken cancellationToken)
        {

            var bytes = await _artProvider.GetImageAsync(artId, cancellationToken);

            return bytes;
        }
        public async Task BuyArtAsync(int artId, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.GetUserIdByHttpContext(cancellationToken);

            var art = await _artProvider.GetItemByIdAsync(artId, cancellationToken);

            art.SellingAvailability = ESellingAvailability.Sold;

            await _artRepository.UpdateAsync(art, cancellationToken);
            await _db.SaveChangesAsync(cancellationToken);
        }
        
    }
}
