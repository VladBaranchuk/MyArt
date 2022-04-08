using MyArt.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MyArt.DataAccess.Configurations
{
    public class LikeFilmsConfiguration : IEntityTypeConfiguration<LikeFilms>
    {
        public void Configure(EntityTypeBuilder<LikeFilms> builder)
        {
            builder.ToTable("LikeFilms");

            builder.HasKey(x => new { x.UserId, x.FilmId });

            builder.HasOne(x => x.User).WithMany(x => x.LikeFilms).HasForeignKey(x => x.UserId);
            builder.HasOne(x => x.Film).WithMany(x => x.LikeFilms).HasForeignKey(x => x.FilmId);
        }
    }
}
