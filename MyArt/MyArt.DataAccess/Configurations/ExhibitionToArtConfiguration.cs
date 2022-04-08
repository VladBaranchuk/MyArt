using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyArt.Domain.Entities;

namespace MyArt.DataAccess.Configurations
{
    public class ExhibitionToArtConfiguration : IEntityTypeConfiguration<ExhibitionToArt>
    {
        public void Configure(EntityTypeBuilder<ExhibitionToArt> builder)
        {
            builder.ToTable("ExhibitionToArt");

            builder.HasKey(x => new { x.ExhibitionId, x.ArtId });

            builder.HasOne(x => x.Exhibition).WithMany(x => x.ExhibitionToArts).HasForeignKey(x => x.ExhibitionId);
            builder.HasOne(x => x.Art).WithMany(x => x.ExhibitionToArts).HasForeignKey(x => x.ArtId);
        }
    }
}
