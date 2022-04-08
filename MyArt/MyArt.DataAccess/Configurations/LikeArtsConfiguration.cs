using MyArt.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MyArt.DataAccess.Configurations
{
    public class LikeArtsConfiguration : IEntityTypeConfiguration<LikeArts>
    {
        public void Configure(EntityTypeBuilder<LikeArts> builder)
        {
            builder.ToTable("LikeArts");

            builder.HasKey(x => new { x.UserId, x.ArtId });

            builder.HasOne(x => x.User).WithMany(x => x.LikeArts).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Art).WithMany(x => x.LikeArts).HasForeignKey(x => x.ArtId);
        }
    }
}
