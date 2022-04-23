
namespace MyArt.API.ViewModels
{
    public class CreateFilmViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string Country { get; set; }
        public string Duration { get; set; }
        public string Producer { get; set; }
        public int Visible { get; set; }
        public int Announcement { get; set; }
        public int Release { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
