using AutoMapper;
using MyArt.API.ViewModels;

namespace MyArt.BusinessLogic.Mappings
{
    public class BoardProfile : Profile
    {
        public BoardProfile()
        {
            CreateMap<ShortBoardViewModel, ShortBoardViewModel>();
        }
    }
}
