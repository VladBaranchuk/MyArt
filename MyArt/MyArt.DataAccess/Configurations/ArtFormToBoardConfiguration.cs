using MyArt.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MyArt.DataAccess.Configurations
{
    public class ArtFormToBoardConfiguration : IEntityTypeConfiguration<ArtFormToBoard>
    {
        public void Configure(EntityTypeBuilder<ArtFormToBoard> builder)
        {
            builder.ToTable("ArtFormToBoard");

            builder.HasKey(x => new { x.ArtFormId, x.BoardId });

            builder.HasOne(x => x.ArtForm).WithMany(x => x.ArtFormToBoards).HasForeignKey(x => x.ArtFormId);
            builder.HasOne(x => x.Board).WithMany(x => x.ArtFormToBoards).HasForeignKey(x => x.BoardId);
        }
    }
}
