using MyArt.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace MyArt.DataAccess.Configurations
{
    public class ExhibitionCommentsConfiguration : IEntityTypeConfiguration<ExhibitionComments>
    {
        public void Configure(EntityTypeBuilder<ExhibitionComments> builder)
        {
            builder.ToTable("ExhibitionComments");

            builder.HasKey(x => new { x.UserId, x.ExhibitionId });
            builder.Property(x => x.Text).IsRequired();
            builder.Property(x => x.Date).IsRequired().HasDefaultValue(DateTime.Now);

            builder.HasOne(x => x.User).WithMany(x => x.ExhibitionComments).HasForeignKey(x => x.UserId);
            builder.HasOne(x => x.Exhibition).WithMany(x => x.ExhibitionComments).HasForeignKey(x => x.ExhibitionId);
        }
    }
}
