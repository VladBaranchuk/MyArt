
namespace MyArt.Domain.Entities
{
    public class ArtFormToArt
    {
        public int ArtFormId { get; set; }
        public int ArtId { get; set; }

        public Art Art { get; set; }
        public ArtForm ArtForm { get; set; }
    }
}
