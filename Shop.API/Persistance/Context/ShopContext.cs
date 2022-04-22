using Microsoft.EntityFrameworkCore;
using Shop.API.Core.Domain.Entity;
using Shop.API.Persistance.Configurations;

namespace Shop.API.Persistance.Context
{
    public class ShopContext:DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options) :base(options)
        {

        }
        public DbSet<Product> Products =>this.Set<Product>();
        public DbSet<Category> Categories => this.Set<Category>();
          public DbSet<AppRole> AppRoles => this.Set<AppRole>();
        public DbSet<AppUser> AppUsers => this.Set<AppUser>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
              base.OnModelCreating(modelBuilder);
        }
       
     }
}
