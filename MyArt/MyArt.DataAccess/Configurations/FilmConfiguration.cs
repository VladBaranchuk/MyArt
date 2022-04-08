using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyArt.Domain.Entities;
using MyArt.Domain.Enums;

namespace MyArt.DataAccess.Configurations
{
    public class FilmConfiguration : IEntityTypeConfiguration<Film>
    {
        public void Configure(EntityTypeBuilder<Film> builder)
        {
            builder.ToTable("Film");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.Country).IsRequired();
            builder.Property(x => x.Duration).IsRequired();
            builder.Property(x => x.Producer).IsRequired();
            builder.Property(x => x.ShareCount);
            builder.Property(x => x.Visible).IsRequired().HasDefaultValue(EVisible.IsVisible);
            builder.Property(x => x.Announcement).IsRequired().HasDefaultValue(EAnnouncement.Announced);
            builder.Property(x => x.Release).IsRequired().HasDefaultValue(ERelease.NotRelease);
            builder.Property(x => x.ReleaseDate).IsRequired();
        }
    }
}
