using MyArt.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyArt.Domain.Enums;
using System;

namespace MyArt.DataAccess.Configurations
{
    public class ArtConfiguration : IEntityTypeConfiguration<Art>
    {
        public void Configure(EntityTypeBuilder<Art> builder)
        {
            builder.ToTable("Art");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.BrightColor).IsRequired();
            builder.Property(x => x.MutedColor).IsRequired();
            builder.Property(x => x.DarkColor).IsRequired();
            builder.Property(x => x.ShareCount);
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.Month);
            builder.Property(x => x.Year);
            builder.Property(x => x.SellingAvailability).IsRequired().HasDefaultValue(ESellingAvailability.Available);
            builder.Property(x => x.Visible).IsRequired().HasDefaultValue(EVisible.IsVisible);
            builder.Property(x => x.Moderation).IsRequired().HasDefaultValue(EModeration.Moderated);
            builder.Property(x => x.Type).IsRequired();
            builder.Property(x => x.Date).IsRequired().HasDefaultValue(DateTime.Now);

            builder.HasOne(x => x.User).WithMany(x => x.Arts).HasForeignKey(x => x.UserId);

        }
    }
}
