
namespace MyArt.API.ViewModels
{
    public class HomeViewModel
    {
        public List<ShortArtViewModel> Arts { get; set; }
        public List<ShortBoardViewModel> Boards { get; set; }
        public List<AuthorViewModel> Authors { get; set; }

        public int Coast { get; set; }
        public int CountAuthors { get; set; }
        public int CountArts { get; set; }
    }
}
