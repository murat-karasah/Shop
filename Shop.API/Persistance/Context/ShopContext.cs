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
        public DbSet<Cart> Carts => this.Set<Cart>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CartItemConfiguration());
              base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AppRole>().HasData(
                new AppRole { Id=1,Definition="Admin"},
                new AppRole { Id=2,Definition="Member"}
                );

            modelBuilder.Entity<AppUser>().HasData(
                new AppUser { Id=1,UserName="kullanici",Password= "kullanici",AppRoleId=2 });
            modelBuilder.Entity<Product>().HasData(
                new Product { Id=1,Name="Iphone 13",Price=1500,Stock=100,CategoryId=1}
                );
            modelBuilder.Entity<Category>().HasData(
                new Category { Id=1,Definition="Telefon"}
                );
        }
       
     }
}
