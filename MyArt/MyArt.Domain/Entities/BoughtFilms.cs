﻿
namespace MyArt.Domain.Entities
{
    public class BoughtFilms
    {
        public int UserId { get; set; }
        public int FilmId { get; set; }

        public User User { get; set; }
        public Film Film { get; set; }
    }
}
