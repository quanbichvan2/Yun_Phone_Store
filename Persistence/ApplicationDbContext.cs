using Microsoft.EntityFrameworkCore;
using Persistence.Entities;

namespace Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Accounts> Accounts { get; set; }
        public DbSet<Brands> Brands { get; set; }
        public DbSet<CartDetails> CartDetails { get; set; }
        public DbSet<Carts> Carts { get; set; }
        public DbSet<Discounts> Discounts { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Profiles> Profiles { get; set; }
        public DbSet<Categories> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }

}
