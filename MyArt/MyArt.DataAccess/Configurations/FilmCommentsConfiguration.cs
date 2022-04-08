using MyArt.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace MyArt.DataAccess.Configurations
{
    public class FilmCommentsConfiguration : IEntityTypeConfiguration<FilmComments>
    {
        public void Configure(EntityTypeBuilder<FilmComments> builder)
        {
            builder.ToTable("FilmComments");

            builder.HasKey(x => new { x.UserId, x.FilmId });
            builder.Property(x => x.Text).IsRequired();
            builder.Property(x => x.Date).IsRequired().HasDefaultValue(DateTime.Now);

            builder.HasOne(x => x.User).WithMany(x => x.FilmComments).HasForeignKey(x => x.UserId);
            builder.HasOne(x => x.Film).WithMany(x => x.FilmComments).HasForeignKey(x => x.FilmId);
        }
    }
}
