﻿using MyArt.Domain.Enums;

namespace MyArt.Domain.Entities
{
    public class Film
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Country { get; set; }
        public string Duration { get; set; }
        public string Producer { get; set; }
        public int ShareCount { get; set; }
        public EVisible Visible { get; set; }
        public EAnnouncement Announcement { get; set; }
        public ERelease Release { get; set; }
        public DateTime AnnouncementDate { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int GenreId { get; set; }
    }
}
