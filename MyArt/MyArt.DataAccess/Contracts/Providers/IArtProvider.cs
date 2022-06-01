using MyArt.API.ViewModels;
using MyArt.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MyArt.DataAccess.Contracts.Providers
{
    public interface IArtProvider : IProvider<Art>
    {
        Task<int> GetLikesCountByIdAsync(int id, CancellationToken cancellationToken);
        Task<int> GetCommentsCountByIdAsync(int id, CancellationToken cancellationToken);
        Task<List<CommentViewModel>> GetCommentsByIdAsync(int id, CancellationToken cancellationToken);
        Task<bool> HasLikedArtByIdAsync(int userId, int artId, CancellationToken cancellationToken);
        Task<List<ShortArtViewModel>> GetAllItemsAsync(int page, int size, int type, CancellationToken cancellationToken);
        Task<List<ShortArtViewModel>> GetAllUserItemsAsync(int userId, int page, int size, CancellationToken cancellationToken);
        Task<List<ShortArtViewModel>> GetAllByArtsFilterAsync(ArtFilterViewModel filter, int page, int size, CancellationToken cancellationToken);
        Task<int> GetPaintingsCountAsync(int id, CancellationToken token);
        Task<int> GetPhotosCountAsync(int id, CancellationToken token);
        Task<int> GetSculpturesCountAsync(int id, CancellationToken token);
        Task<byte[]> GetImageAsync(int artId, CancellationToken cancellationToken);
        Task<List<ShortArtViewModel>> GetAllNewUserItemsAsync(int userId, int page, int size, CancellationToken cancellationToken);
        Task<bool> HasAnyItemByIdAsync(int id, CancellationToken cancellationToken);
        Task<bool> HasOnBoardArtByIdAsync(int userId, int artId, CancellationToken cancellationToken);
        Task<List<ShortArtViewModel>> GetAllBoardItemsAsync(int boardId, int page, int size, CancellationToken cancellationToken);
        Task<int> GetFullCoastAsync(CancellationToken cancellationToken);
        Task<int> GetAllCountAsync(CancellationToken cancellationToken);
    }
}
