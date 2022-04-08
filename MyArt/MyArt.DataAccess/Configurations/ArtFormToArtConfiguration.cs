using MyArt.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MyArt.DataAccess.Configurations
{
    public class ArtFormToArtConfiguration : IEntityTypeConfiguration<ArtFormToArt>
    {
        public void Configure(EntityTypeBuilder<ArtFormToArt> builder)
        {
            builder.ToTable("ArtFormToArt");

            builder.HasKey(x => new { x.ArtFormId, x.ArtId });

            builder.HasOne(x => x.ArtForm).WithMany(x =>x.ArtFormToArts).HasForeignKey(x=>x.ArtFormId);
            builder.HasOne(x => x.Art).WithMany(x =>x.ArtFormToArts).HasForeignKey(x=>x.ArtId);
        }
    }
}
