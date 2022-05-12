
namespace MyArt.API.ViewModels
{
    public class AuthorViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Alias { get; set; }
        public List<ShortArtViewModel> Arts { get; set; }
    }
}
