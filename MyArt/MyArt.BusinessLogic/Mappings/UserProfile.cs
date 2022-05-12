using AutoMapper;
using MyArt.API.ViewModels;
using MyArt.Domain.Entities;

namespace MyArt.BusinessLogic.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<RegisterViewModel, User>();
            CreateMap<AuthenticationViewModel, User>();

            CreateMap<User, UserViewModel>()
                .ForMember(
                    dest => dest.Role,
                    opt => opt.MapFrom(x => x.RoleToUsers[0].Role.Name)
                );

            CreateMap<User, ShortUserInfoViewModel>()
               .ForMember(
                   dest => dest.Role,
                   opt => opt.MapFrom(x => x.RoleToUsers[0].Role.Name)
               );

            CreateMap<User, UpdatePublicUserInfoViewModel>();
            CreateMap<AuthorViewModel, AuthorViewModel>();
        }
    }
}
