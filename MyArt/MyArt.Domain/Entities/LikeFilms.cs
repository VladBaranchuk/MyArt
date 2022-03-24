
namespace MyArt.Domain.Entities
{
    public class LikeFilms
    {
        public int UserId { get; set; }
        public int FilmId { get; set; }

        public User User { get; set; }
        public Film Film { get; set; }
    }
}
