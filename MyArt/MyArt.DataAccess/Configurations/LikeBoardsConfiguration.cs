using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyArt.Domain.Entities;

namespace MyArt.DataAccess.Configurations
{
    public class LikeBoardsConfiguration : IEntityTypeConfiguration<LikeBoards>
    {
        public void Configure(EntityTypeBuilder<LikeBoards> builder)
        {
            builder.ToTable("LikeBoards");

            builder.HasKey(x => new { x.UserId, x.BoardId });

            builder.HasOne(x => x.User).WithMany(x => x.LikeBoards).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Board).WithMany(x => x.LikeBoards).HasForeignKey(x => x.BoardId);
        }
    }
}
