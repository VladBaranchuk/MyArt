
namespace MyArt.API.ViewModels
{
    public class FilmsDetailedInfoViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string Country { get; set; }
        public string Duration { get; set; }
        public string Producer { get; set; }
        public int? ShareCount { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
