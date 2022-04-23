
namespace MyArt.Domain.Entities
{
    public class ArtComments
    {
        public int UserId { get; set; }
        public int ArtId { get; set; }
        public int CommentId { get; set; }

        public User User { get; set; }
        public Art Art { get; set; }
        public Comment Comment { get; set; }
    }
}
