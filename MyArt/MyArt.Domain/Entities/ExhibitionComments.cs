
namespace MyArt.Domain.Entities
{
    public class ExhibitionComments
    {
        public int UserId { get; set; }
        public int ExhibitionId { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
    }
}
