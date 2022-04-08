using MyArt.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MyArt.DataAccess.Configurations
{
    public class ArtToBoardConfiguration : IEntityTypeConfiguration<ArtToBoard>
    {
        public void Configure(EntityTypeBuilder<ArtToBoard> builder)
        {
            builder.ToTable("ArtToBoard");

            builder.HasKey(x => new { x.BoardId, x.ArtId });

            builder.HasOne(x => x.Art).WithMany(x => x.ArtToBoards).HasForeignKey(x => x.BoardId);
            builder.HasOne(x => x.Board).WithMany(x => x.ArtToBoards).HasForeignKey(x => x.ArtId);
        }
    }
}
