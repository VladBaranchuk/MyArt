using MyArt.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MyArt.DataAccess.Configurations
{
    public class LikeExhibitionsConfiguration : IEntityTypeConfiguration<LikeExhibitions>
    {
        public void Configure(EntityTypeBuilder<LikeExhibitions> builder)
        {
            builder.ToTable("LikeExhibitions");

            builder.HasKey(x => new { x.UserId, x.ExhibitionId });

            builder.HasOne(x => x.User).WithMany(x => x.LikeExhibitions).HasForeignKey(x => x.UserId);
            builder.HasOne(x => x.Exhibition).WithMany(x => x.LikeExhibitions).HasForeignKey(x => x.ExhibitionId);
        }
    }
}
