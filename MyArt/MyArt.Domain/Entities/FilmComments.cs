
namespace MyArt.Domain.Entities
{
    public class FilmComments
    {
        public int UserId { get; set; }
        public int FilmId { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
    }
}
