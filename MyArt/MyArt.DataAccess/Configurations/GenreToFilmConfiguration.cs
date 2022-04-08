using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyArt.Domain.Entities;

namespace MyArt.DataAccess.Configurations
{
    public class GenreToFilmConfiguration : IEntityTypeConfiguration<GenreToFilm>
    {
        public void Configure(EntityTypeBuilder<GenreToFilm> builder)
        {
            builder.ToTable("GenreToFilm");

            builder.HasKey(x => new { x.FilmId, x.GenreId });

            builder.HasOne(x => x.Film).WithMany(x => x.GenreToFilms).HasForeignKey(x => x.FilmId);
            builder.HasOne(x => x.Genre).WithMany(x => x.GenreToFilms).HasForeignKey(x => x.GenreId);
        }
    }
}
