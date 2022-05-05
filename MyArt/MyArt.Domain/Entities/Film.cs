using MyArt.Domain.Enums;

namespace MyArt.Domain.Entities
{
    public class Film
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string Country { get; set; }
        public string Duration { get; set; }
        public string Producer { get; set; }
        public int? ShareCount { get; set; }
        public EVisible Visible { get; set; }
        public EAnnouncement Announcement { get; set; }
        public ERelease Release { get; set; }
        public DateTime ReleaseDate { get; set; }
        public byte[] Data { get; set; }

        public List<GenreToFilm> GenreToFilms { get; set; }
        public List<LikeFilms> LikeFilms { get; set; }
        public List<FilmComments> FilmComments { get; set; }
        public List<BoughtFilms> BoughtFilms { get; set; }
    }
}
