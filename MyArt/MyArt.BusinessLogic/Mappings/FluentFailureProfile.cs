using AutoMapper;
using FluentValidation.Results;
using MyArt.BusinessLogic.Models;

namespace MyArt.BusinessLogic.Mappings
{
    public class FluentFailureProfile : Profile
    {
        public FluentFailureProfile()
        {
            CreateMap<ValidationFailure, FluentFailure>()
                .ForMember(
                    dest => dest.Message,
                    opt => opt.MapFrom(x => x.ErrorMessage)
                );
        }
    }
}
