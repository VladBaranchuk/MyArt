using MyArt.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyArt.Domain.Enums;

namespace MyArt.DataAccess.Configurations
{
    public class ExhibitionConfiguration : IEntityTypeConfiguration<Exhibition>
    {
        public void Configure(EntityTypeBuilder<Exhibition> builder)
        {
            builder.ToTable("Exhibition");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.AnnounceDate).IsRequired();
            builder.Property(x => x.ReleaseDate);
            builder.Property(x => x.ExpirationDate);
            builder.Property(x => x.ShareCount);
            builder.Property(x => x.Visible).IsRequired().HasDefaultValue(EVisible.IsVisible);
            builder.Property(x => x.Moderation).IsRequired().HasDefaultValue(EModeration.NotModerated);
            builder.Property(x => x.Announcement).IsRequired().HasDefaultValue(EAnnouncement.Announced);
            builder.Property(x => x.Release).IsRequired().HasDefaultValue(ERelease.NotRelease);
        }
    }
}
