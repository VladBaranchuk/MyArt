
namespace MyArt.API.ViewModels
{
    public class ShortBoardViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public int? FirstId { get; set; }
        public int LikesCount { get; set; }
        public int ShareCount { get; set; }
        public bool HasLiked { get; set; }
    }
}
