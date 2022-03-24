
namespace MyArt.Domain.Entities
{
    public class LikeArts
    {
        public int UserId { get; set; }
        public int ArtId { get; set; }

        public Art Art { get; set; }
        public User User { get; set; }
    }
}
