using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pro.Domain.Models;

namespace Pro.Infrastructure.ModelConfigurations
{
    public class PropertyConfig : IEntityTypeConfiguration<Property>
    {
        public void Configure(EntityTypeBuilder<Property> builder)
        {

            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("NEWID()");

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(p => p.MainImgId)
                .IsRequired(false);

            builder.Property(p => p.CreatedAt)
                .HasDefaultValueSql("GETDATE()");

            builder.HasOne(p => p.MainImg)
                .WithMany()
                .HasForeignKey(p => p.MainImgId)
                .OnDelete(DeleteBehavior.Restrict);



        }
    }
}
