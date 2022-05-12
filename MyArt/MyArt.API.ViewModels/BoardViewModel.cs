
namespace MyArt.API.ViewModels
{
    public class BoardViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public int? FirstId { get; set; }
        public string BrightColor { get; set; }
        public string MutedColor { get; set; }
        public string DarkColor { get; set; }
        public int LikesCount { get; set; }
        public int? ShareCount { get; set; }
        public bool HasLiked { get; set; }
        public List<ShortArtViewModel> Arts { get; set; }
    }
}
