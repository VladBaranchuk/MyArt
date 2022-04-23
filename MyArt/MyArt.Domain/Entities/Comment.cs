namespace MyArt.Domain.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }

        public List<FilmComments> FilmComments { get; set; }
        public List<ArtComments> ArtComments { get; set; }
        public List<ExhibitionComments> ExhibitionComments { get; set; }
    }
}
