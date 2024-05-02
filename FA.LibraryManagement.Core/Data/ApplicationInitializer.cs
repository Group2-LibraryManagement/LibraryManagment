using FA.LibraryManagement.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace FA.LibraryManagement.Core.Data;

/// <summary>
///     The application initializer class
/// </summary>
public static class ApplicationInitializer
{
    /// <summary>
    ///     Seeds the model builder
    /// </summary>
    /// <param name="modelBuilder">The model builder</param>
    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Role>().HasData(
            new Role
            {
                Id = 1,
                Name = "BlogOwner",
                NormalizedName = "BLOGOWNER",
                Description = "This is role Blog owner"
            },
            new Role
            {
                Id = 2,
                Name = "Contributor",
                NormalizedName = "CONTRIBUTOR",
                Description = "This is role contributor"
            },
            new Role
            {
                Id = 3,
                Name = "User",
                NormalizedName = "USER",
                Description = "This is role user or guest"
            }
        );

        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = 1,
                Email = "trungsangle123@gmail.com",
                PasswordHash = "AQAAAAIAAYagAAAAEF+kflztPRzXy/uVDeXi7oc4yNo5ze+AtYcauF4WpN9sZX4/bUJZXgWBftHDzeAVRw==",
                UserName = "sanglt5",
                SecurityStamp = "23XYSO4Z3J4WWLXHGVQ35GIRRDPNVN2R",
                ConcurrencyStamp = "225095a0-5ce9-4ebc-a51c-08d11a168f78",
                NormalizedEmail = "TRUNGSANGLE123@GMAIL.COM",
                NormalizedUserName = "SANGLT5",
                LockoutEnabled = true,
                TwoFactorEnabled = false,
                PhoneNumberConfirmed = false,
                EmailConfirmed = false,
                PhoneNumber = "0123456789",
                AccessFailedCount = 0,
                LockoutEnd = null
            }
        );

        modelBuilder.Entity<UserRole>().HasData(
            new UserRole
            {
                UserId = 1,
                RoleId = 1
            },
            new UserRole
            {
                UserId = 1,
                RoleId = 2
            }
        );

        modelBuilder.Entity<Category>().HasData(
            new Category
            {
                Id = 1,
                Name = "Technology",
                UrlSlug = "abc.com"
            },
            new Category
            {
                Id = 2,
                Name = "Health",
                UrlSlug = "abc.com"
            },
            new Category
            {
                Id = 3,
                Name = "Sport",
                UrlSlug = "abc.com"
            }
        );
    }
}