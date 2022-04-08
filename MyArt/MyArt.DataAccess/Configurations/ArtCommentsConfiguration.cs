using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyArt.Domain.Entities;
using System;

namespace MyArt.DataAccess.Configurations
{
    public class ArtCommentsConfiguration : IEntityTypeConfiguration<ArtComments>
    {
        public void Configure(EntityTypeBuilder<ArtComments> builder)
        {
            builder.ToTable("ArtComments");

            builder.HasKey(x => new { x.UserId, x.ArtId });
            builder.Property(x => x.Text).IsRequired();
            builder.Property(x => x.Date).IsRequired().HasDefaultValue(DateTime.Now);

            builder.HasOne(x => x.User).WithMany(x => x.ArtComments).HasForeignKey(x => x.UserId);
            builder.HasOne(x => x.Art).WithMany(x => x.ArtComments).HasForeignKey(x => x.ArtId);
        }
    }
}
