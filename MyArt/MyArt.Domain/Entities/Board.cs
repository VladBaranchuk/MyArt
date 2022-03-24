
using MyArt.Domain.Enums;

namespace MyArt.Domain.Entities
{
    public class Board
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public EVisible Visible { get; set; }
        public int ShareCount { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }

        public User User { get; set; }
        public List<ArtToBoard> ArtToBoards { get; set; }
        public List<LikeBoards> LikeBoards { get; set; }
        public List<ArtFormToBoard> ArtFormToBoards { get; set; }
    }
}
