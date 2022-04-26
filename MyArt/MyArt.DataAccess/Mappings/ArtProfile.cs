using AutoMapper;
using MyArt.API.ViewModels;

namespace MyArt.DataAccess.Mappings
{
    public class ArtProfile : Profile
    {
        public ArtProfile()
        {
            CreateMap<ShortArtViewModel, ShortArtViewModel>();
        }
    }
}
