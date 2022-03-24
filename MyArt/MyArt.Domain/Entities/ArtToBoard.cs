
namespace MyArt.Domain.Entities
{
    public class ArtToBoard
    {
        public int ArtId { get; set; }
        public int BoardId { get; set; }

        public Art Art { get; set; }
        public Board Board { get; set; }
    }
}
