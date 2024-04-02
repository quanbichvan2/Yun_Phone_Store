using Microsoft.EntityFrameworkCore;
using Persistence.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace Persistence.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        // entity trong phần model đặt tên không thêm 's', nhưng mà đoạn ánh xạ dưới thì phải thêm 's' 
        // 1 đối tượng đại diện cho 1 thực thể, còn trong trường hợp dbSet thì phải có s. Nếu đặt model mà có s thì lúc làm list mà thêm s thì sẽ gây ra hiểu lầm. 
        public DbSet<Brand> Brands { get; set; }
        public DbSet<CartDetail> CartDetails { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

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
