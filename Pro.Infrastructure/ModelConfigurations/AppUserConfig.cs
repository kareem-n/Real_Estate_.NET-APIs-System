using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pro.Domain.Models;

namespace Pro.Infrastructure.ModelConfigurations
{
    public class AppUserConfig : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasIndex(u => u.Email)
                .IsUnique();

            builder.Property(u => u.DateOfBirth)
                .IsRequired();

            builder.Property(u => u.Address)
                .HasMaxLength(200);

            builder.Property(u => u.ProfileImgPath)
                .IsRequired(false);


        }
    }
}
