using MyArt.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MyArt.DataAccess.Configurations
{
    public class RoleToUserConfiguration : IEntityTypeConfiguration<RoleToUser>
    {
        public void Configure(EntityTypeBuilder<RoleToUser> builder)
        {
            builder.ToTable("RoleToUser");

            builder.HasKey(x => new { x.UserId, x.RoleId });

            builder.HasOne(x => x.User).WithMany(x => x.RoleToUsers).HasForeignKey(x => x.UserId);
            builder.HasOne(x => x.Role).WithMany(x => x.RoleToUsers).HasForeignKey(x => x.RoleId);
        }
    }
}
