
namespace MyArt.Domain.Entities
{
    public class ExhibitionComments
    {
        public int UserId { get; set; }
        public int ExhibitionId { get; set; }
        public int CommentId { get; set; }

        public User User { get; set; }
        public Exhibition Exhibition { get; set; }
        public Comment Comment { get; set; }
    }
}
