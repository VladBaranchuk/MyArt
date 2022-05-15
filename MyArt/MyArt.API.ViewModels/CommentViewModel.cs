namespace MyArt.API.ViewModels
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Alias { get; set; }
        public string Text { get; set; }
        public string Date { get; set; }
    }
}
