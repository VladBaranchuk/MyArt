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

            builder.HasKey(x => new { x.UserId, x.ExhibitionId, x.CommentId });

            builder.HasOne(x => x.User).WithMany(x => x.ExhibitionComments).HasForeignKey(x => x.UserId);
            builder.HasOne(x => x.Comment).WithMany(x =>x.ExhibitionComments).HasForeignKey(x => x.CommentId);  
            builder.HasOne(x => x.Exhibition).WithMany(x => x.ExhibitionComments).HasForeignKey(x => x.ExhibitionId);
        }
    }
}
