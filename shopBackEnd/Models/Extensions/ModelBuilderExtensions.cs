using shopBackEnd.Models.DataModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using shopBackEnd.Models.Enums;

namespace dShopBackEnd.Data.Extensions
{

    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {





            modelBuilder.Entity<Category>().HasData(
                  new Category()
                  {
                      Id = 1,
                      Name = "Áo nam",
                      SeoAlias = "ao-nam",
                      SeoDescription = "Sản phẩm áo thời trang nam",
                      SeoTitle = "Sản phẩm áo thời trang nam",
                      IsShowOnHome = true,
                      ParentId = null,
                      Status = Status.Active
                  },
                  new Category()
                  {
                      Id = 2,
                      Name = "Áo nữ",
                      SeoAlias = "ao-nu",
                      SeoDescription = "Sản phẩm áo thời trang nữ",
                      SeoTitle = "Sản phẩm áo thời trang nữ",
                      IsShowOnHome = true,
                      ParentId = null,
                      Status = Status.Active,
                  }
                    );
            modelBuilder.Entity<Product>().HasData(
                 new Product()
                 {
                     Id = 1,
                     Name = "Áo sơ mi nam trắng Việt Tiến",
                     DateCreated = DateTime.Now,
                     Price = 200000,
                     Sale_Price = 100000,
                     Stock = 0,
                     ViewCount = 0,
                     SeoAlias = "ao-so-mi-nam-trang-viet-tien",
                     SeoDescription = "Áo sơ mi nam trắng Việt Tiến",
                     SeoTitle = "Áo sơ mi nam trắng Việt Tiến",
                     Details = "Áo sơ mi nam trắng Việt Tiến",
                     Description = "Áo sơ mi nam trắng Việt Tiến",
                     CategoryId = 1,
                 },
                    new Product()
                    {
                        Id = 2,
                        CategoryId = 2,
                        DateCreated = DateTime.Now,
                        Price = 200000,
                        Sale_Price = 100000,
                        Name = "Viet Tien Men T-Shirt",
                        SeoAlias = "viet-tien-men-t-shirt",
                        SeoDescription = "Viet Tien Men T-Shirt",
                        SeoTitle = "Viet Tien Men T-Shirt",
                        Details = "Viet Tien Men T-Shirt",
                        Description = "Viet Tien Men T-Shirt"
                    });

            // any guid
            var roleId = new Guid("8D04DCE2-969A-435D-BBA4-DF3F325983DC");
            var adminId = new Guid("69BD714F-9576-45BA-B5B7-F00649BE00DE");
            modelBuilder.Entity<AppRole>().HasData(new AppRole
            {
                Id = roleId,
                Name = "admin",
                NormalizedName = "admin",
                Description = "Administrator role"
            });

            var hasher = new PasswordHasher<AppUser>();
            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                Id = adminId,
                UserName = "admin",
                NormalizedUserName = "admin",
                Email = "datmarcinho11@gmail.com",
                NormalizedEmail = "datmarcinho11@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Abcd1234$"),
                SecurityStamp = string.Empty,
                FirstName = "Dat",
                LastName = "Nguyen",
                Dob = new DateTime(2002, 03, 13)
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = roleId,
                UserId = adminId
            });
        }



    }
}
