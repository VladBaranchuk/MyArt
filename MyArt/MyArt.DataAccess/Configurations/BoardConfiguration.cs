using MyArt.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyArt.Domain.Enums;
using System;

namespace MyArt.DataAccess.Configurations
{
    public class BoardConfiguration : IEntityTypeConfiguration<Board>
    {
        public void Configure(EntityTypeBuilder<Board> builder)
        {
            builder.ToTable("Board");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Visible).IsRequired().HasDefaultValue(EVisible.IsVisible);
            builder.Property(x => x.ShareCount).IsRequired(false);
            builder.Property(x => x.Date).IsRequired().HasDefaultValue(DateTime.Now);

            builder.HasOne(x => x.User).WithMany(x => x.Boards).HasForeignKey(x => x.UserId);
        }
    }
}
