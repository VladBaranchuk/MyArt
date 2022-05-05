using AutoMapper;
using MyArt.API.ViewModels;
using MyArt.Domain.Entities;

namespace MyArt.BusinessLogic.Mappings
{
    public class ArtProfile : Profile
    {
        public ArtProfile()
        {
            CreateMap<ShortArtViewModel, ShortArtViewModel>();

            CreateMap<Comment, CommentViewModel>();
        }
    }
}
