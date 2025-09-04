using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pro.Domain.Models;
using Pro.Infrastructure.ModelConfigurations;

namespace Pro.Infrastructure.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {

        public DbSet<Property> Properties { get; set; }
        public DbSet<Image> Images { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(AppUserConfig).Assembly);
        }

    }
}
