
namespace MyArt.API.ViewModels
{
    public class CabinetViewModel
    {
        public int Id { get; set; }
        public string Alias { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PaintingsCount { get; set; }
        public int PhotosCount { get; set; }
        public int SculpturesCount { get; set; }
        public string Description { get; set; }
        public List<ShortArtViewModel> Arts { get; set; }
        public List<ShortBoardViewModel> Boards { get; set; }
    }

}
