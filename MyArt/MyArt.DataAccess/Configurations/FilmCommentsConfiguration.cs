using MyArt.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MyArt.DataAccess.Configurations
{
    public class FilmCommentsConfiguration : IEntityTypeConfiguration<FilmComments>
    {
        public void Configure(EntityTypeBuilder<FilmComments> builder)
        {
            builder.ToTable("FilmComments");

            builder.HasKey(x => new { x.UserId, x.FilmId, x.CommentId });

            builder.HasOne(x => x.User).WithMany(x => x.FilmComments).HasForeignKey(x => x.UserId);
            builder.HasOne(x => x.Comment).WithMany(x => x.FilmComments).HasForeignKey(x => x.CommentId).OnDelete(DeleteBehavior.NoAction); ;
            builder.HasOne(x => x.Film).WithMany(x => x.FilmComments).HasForeignKey(x => x.FilmId);
        }
    }
}
