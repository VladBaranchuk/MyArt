using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyArt.Domain.Entities;

namespace MyArt.DataAccess.Configurations
{
    public class ArtCommentsConfiguration : IEntityTypeConfiguration<ArtComments>
    {
        public void Configure(EntityTypeBuilder<ArtComments> builder)
        {
            builder.ToTable("ArtComments");

            builder.HasKey(x => new { x.UserId, x.ArtId, x.CommentId });

            builder.HasOne(x => x.Art).WithMany(x => x.ArtComments).HasForeignKey(x => x.ArtId);
            builder.HasOne(x => x.Comment).WithMany(x => x.ArtComments).HasForeignKey(x => x.CommentId);
            builder.HasOne(x => x.User).WithMany(x => x.ArtComments).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
