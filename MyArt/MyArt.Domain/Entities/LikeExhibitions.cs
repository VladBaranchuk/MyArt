
namespace MyArt.Domain.Entities
{
    public class LikeExhibitions
    {
        public int UserId { get; set; }
        public int ExhibitionId { get; set; }

        public User User { get; set; }
        public Exhibition Exhibition { get; set; }
    }
}
