
using Microsoft.AspNetCore.Http;

namespace MyArt.API.ViewModels
{
    public class CreateArtViewModel
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Month { get; set; }
        public string Year { get; set; }
        public int Type { get; set; }
        public string? ArtForm { get; set; }
        public string? Material { get; set; }
        public int? Size { get; set; }
        public IFormFile Image { get; set; }
    }
}
