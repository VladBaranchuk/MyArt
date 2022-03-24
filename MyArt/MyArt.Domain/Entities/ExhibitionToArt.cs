
namespace MyArt.Domain.Entities
{
    public class ExhibitionToArt
    {
        public int ExhibitionId { get; set; }
        public int ArtId { get; set; }

        public Art Art { get; set; }
        public Exhibition Exhibition { get; set; }
    }
}
