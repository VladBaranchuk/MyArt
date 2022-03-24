
namespace MyArt.Domain.Entities
{
    public class ArtFormToBoard
    {
        public int ArtFormId { get; set; }
        public int BoardId { get; set; }

        public Board Board { get; set; }
        public ArtForm ArtForm { get; set; }
    }
}
