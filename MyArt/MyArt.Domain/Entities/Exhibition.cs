
using MyArt.Domain.Enums;

namespace MyArt.Domain.Entities
{
    public class Exhibition
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime AnnounceDate { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int ShareCount { get; set; }
        public EVisible Visible { get; set; }
        public EModeration Moderation { get; set; }
        public EAnnouncement Announcement { get; set; }
        public ERelease Release { get; set; }

        public List<ExhibitionToArt> ExhibitionToArts { get; set; }
        public List<LikeExhibitions> LikeExhibitions { get; set; }
        public List<ExhibitionComments> ExhibitionComments { get; set; }
        public List<ExhibitionToArtForm> ExhibitionToArtForms { get; set; }

    }
}
