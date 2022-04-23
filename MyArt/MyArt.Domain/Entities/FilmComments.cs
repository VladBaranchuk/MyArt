
namespace MyArt.Domain.Entities
{
    public class FilmComments
    {
        public int UserId { get; set; }
        public int FilmId { get; set; }
        public int CommentId { get; set; }

        public User User { get; set; }
        public Film Film { get; set; }
        public Comment Comment { get; set; }
    }
}
