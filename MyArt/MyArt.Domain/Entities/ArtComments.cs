
namespace MyArt.Domain.Entities
{
    public class ArtComments
    {
        public int UserId { get; set; }
        public int ArtId { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
    }
}
