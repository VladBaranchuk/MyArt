
using Microsoft.AspNetCore.Http;

namespace MyArt.BusinessLogic.Contracts
{
    public interface IColorService
    {
        string[] GetColorPalette(IFormFile img);
    }
}
