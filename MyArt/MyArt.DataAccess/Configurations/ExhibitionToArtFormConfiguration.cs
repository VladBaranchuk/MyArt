using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyArt.Domain.Entities;

namespace MyArt.DataAccess.Configurations
{
    public class ExhibitionToArtFormConfiguration : IEntityTypeConfiguration<ExhibitionToArtForm>
    {
        public void Configure(EntityTypeBuilder<ExhibitionToArtForm> builder)
        {
            builder.ToTable("ExhibitionToArtForm");

            builder.HasKey(x => new { x.ExhibitionId, x.ArtFormId });

            builder.HasOne(x => x.Exhibition).WithMany(x => x.ExhibitionToArtForms).HasForeignKey(x => x.ExhibitionId);
            builder.HasOne(x => x.ArtForm).WithMany(x => x.ExhibitionToArtForms).HasForeignKey(x => x.ArtFormId);
        }
    }
}
