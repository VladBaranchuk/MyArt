using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyArt.Domain.Entities;

namespace MyArt.DataAccess.Configurations
{
    public class ArtFormConfiguration : IEntityTypeConfiguration<ArtForm>
    {
        public void Configure(EntityTypeBuilder<ArtForm> builder)
        {
            builder.ToTable("ArtForm");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired();
        }
    }
}
