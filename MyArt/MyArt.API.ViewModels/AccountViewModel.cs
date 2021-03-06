
namespace MyArt.API.ViewModels
{
    public class AccountViewModel
    {
        public int Id { get; set; }
        public string Alias { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int PaintingsCount { get; set; }
        public int PhotosCount { get; set; }
        public int SculpturesCount { get; set; }
        public string Description { get; set; }
        public List<ShortArtViewModel> NewArts { get; set; }
        public List<ShortArtViewModel> Arts { get; set; }
    }
}
