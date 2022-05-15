
namespace MyArt.API.ViewModels
{
    public class HomeViewModel
    {
        public List<ShortArtViewModel> Arts { get; set; }
        public List<ShortBoardViewModel> Boards { get; set; }
        public List<AuthorViewModel> Authors { get; set; }
    }
}
