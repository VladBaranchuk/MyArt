
namespace MyArt.API.ViewModels
{
    public class ArtViewModel
    {
        public int Id { get; set; }
        public string Alias { get; set; }
        public string Name { get; set; }
        public string BrightColor { get; set; }
        public string MutedColor { get; set; }
        public string DarkColor { get; set; }
        public int Price { get; set; }
        public int? ShareCount { get; set; }
        public string? Month { get; set; }
        public string Year { get; set; }
        public int SellingAvailability { get; set; }
        public int Visible { get; set; }
        public int Moderation { get; set; }
        public int Type { get; set; }
        public int LikesCount { get; set; }
        public int CommentsCount { get; set; }
        public bool HasLiked { get; set; }
        public bool HasOnBoard { get; set; }
        public List<ShortArtViewModel> Arts { get; set; }
        public List<CommentViewModel> Comments { get; set; }
    }
}
