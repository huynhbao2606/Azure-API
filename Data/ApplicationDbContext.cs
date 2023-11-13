using Microsoft.EntityFrameworkCore;
using AzureAPI.Entities;

namespace AzureAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductBrand> ProductBrand { get; set; }

        public DbSet<ProductType> ProductType { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Product>().HasData(
                new Product
                { Id = 1, Name = "Inactivated"},
                new Product
                { Id = 2, Name = "Live-attenuated"},
                new Product
                { Id = 3, Name = "Messenger RNA (mRNA)"},
                new Product
                { Id = 4, Name = "Subunit, recombinant, polysaccharide, and conjugate" });
        }
    }
    
}
