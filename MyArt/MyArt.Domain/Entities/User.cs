
namespace MyArt.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Alias { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Description { get; set; }
        public byte[] Data { get; set; }

        public List<Art> Arts { get; set; }
        public List<Board> Boards { get; set; }
        public List<LikeBoards> LikeBoards { get; set; }
        public List<ArtComments> ArtComments { get; set; }
        public List<LikeArts> LikeArts { get; set; }
        public List<LikeFilms> LikeFilms { get; set; }
        public List<FilmComments> FilmComments { get; set; }
        public List<BoughtFilms> BoughtFilms { get; set; }
        public List<LikeExhibitions> LikeExhibitions { get; set; }
        public List<ExhibitionComments> ExhibitionComments { get; set; }
        public List<RoleToUser> RoleToUsers { get; set; }
    }
}
