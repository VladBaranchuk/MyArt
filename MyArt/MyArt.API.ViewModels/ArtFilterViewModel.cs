
namespace MyArt.API.ViewModels
{
    public class ArtFilterViewModel
    {
        public string Year { get; set; }
        public int? MinPrice { get; set; }
        public int? MaxPrice { get; set; }
        public bool Popular { get; set; }
        public int? Type { get; set; }
    }
}
