
namespace MyArt.Domain.Entities
{
    public class ArtForm
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<ArtFormToBoard> ArtFormToBoards { get; set; }
        public List<ArtFormToArt> ArtFormToArts { get; set; }
        public List<ExhibitionToArtForm> ExhibitionToArtForms { get; set; }
    }
}
