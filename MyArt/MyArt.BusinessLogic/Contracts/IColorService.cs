
using Microsoft.AspNetCore.Http;
using MyArt.API.ViewModels;

namespace MyArt.BusinessLogic.Contracts
{
    public interface IColorService
    {
        ColorsViewModel GetColorPalette(IFormFile img, int numberOfColors, int imageGranularity = 5, int colorGranularity = 11);
    }
}
