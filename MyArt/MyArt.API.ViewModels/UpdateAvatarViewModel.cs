using Microsoft.AspNetCore.Http;

namespace MyArt.API.ViewModels
{
    public class UpdateAvatarViewModel
    {
        public IFormFile Avatar { get; set; }
    }
}
