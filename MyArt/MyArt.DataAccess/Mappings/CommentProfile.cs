using AutoMapper;
using MyArt.API.ViewModels;
using MyArt.Domain.Entities;

namespace MyArt.DataAccess.Mappings
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<FilmComments, CommentViewModel>()
                .ForMember(
                    dest => dest.Alias,
                    opt => opt.MapFrom(x => x.User.Alias)
                );
        }
    }
}
