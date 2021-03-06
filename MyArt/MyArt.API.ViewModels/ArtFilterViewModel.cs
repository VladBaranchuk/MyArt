
namespace MyArt.API.ViewModels
{
    public class ArtFilterViewModel
    {
        public int? Year { get; set; }
        public int? MinPrice { get; set; }
        public int? MaxPrice { get; set; }
        public bool Popular { get; set; }
        public string? Material { get; set; }
        public string? ArtForm { get; set; }
        public int? Size { get; set; }
        public int? Type { get; set; }
    }
}
