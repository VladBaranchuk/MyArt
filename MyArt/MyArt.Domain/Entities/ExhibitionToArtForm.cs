
namespace MyArt.Domain.Entities
{
    public class ExhibitionToArtForm
    {
        public int ExhibitionId { get; set; }
        public int ArtFormId { get; set; }

        public Exhibition Exhibition { get; set; }
        public ArtForm ArtForm { get; set; }
    }
}
