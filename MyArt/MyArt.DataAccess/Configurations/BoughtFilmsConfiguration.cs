using MyArt.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MyArt.DataAccess.Configurations
{
    public class BoughtFilmsConfiguration : IEntityTypeConfiguration<BoughtFilms>
    {
        public void Configure(EntityTypeBuilder<BoughtFilms> builder)
        {
            builder.ToTable("BoughtFilms");

            builder.HasKey(x => new { x.FilmId, x.UserId });

            builder.HasOne(x => x.User).WithMany(x => x.BoughtFilms).HasForeignKey(x => x.UserId);
            builder.HasOne(x => x.Film).WithMany(x => x.BoughtFilms).HasForeignKey(x => x.FilmId);
        }
    }
}
