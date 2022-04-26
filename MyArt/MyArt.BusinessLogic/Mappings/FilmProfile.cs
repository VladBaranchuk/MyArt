using AutoMapper;
using MyArt.API.ViewModels;
using MyArt.Domain.Entities;

namespace MyArt.BusinessLogic.Mappings
{
    public class FilmProfile : Profile
    {
        public FilmProfile()
        {
            CreateMap<Film, FilmViewModel>();
            CreateMap<ShortFilmViewModel, ShortFilmViewModel>();
        }
    }
}
