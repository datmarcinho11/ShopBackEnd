using dShopBackEnd.Data.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using shopBackEnd.Models.DataModels;

namespace shopBackEnd.Models.BusinessModels
{
    public class ShopDbContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public ShopDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Category>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<Category>(c =>
            {
                c.Property(col => col.Id).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<Product>().HasIndex(p => p.Name).IsUnique();
            modelBuilder.Entity<Product>(p =>
            {
                p.Property(col => col.Id).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<ProductImage>(pI =>
            {
                pI.Property(col => col.Id).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<Cart>(ca =>
            {
                ca.Property(col => col.Id).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<Order>(o =>
            {
                o.Property(col => col.Id).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<OrderDetail>(od =>
            {
                od.Property(col => col.Id).ValueGeneratedOnAdd();
            });
            //Configure using Fluent API


            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaims");
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRoles").HasKey(x => new { x.UserId, x.RoleId });
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogins").HasKey(x => x.UserId);

            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaims");
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserTokens").HasKey(x => x.UserId);

            //Data seeding
            modelBuilder.Seed();
            //base.OnModelCreating(modelBuilder);
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
    }
}
