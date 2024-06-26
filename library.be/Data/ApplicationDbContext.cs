using library.be.Domain;
using library.be.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace library.be.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        public ApplicationDbContext()
        {
            
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}

        public DbSet<ApplicationUser> applicationUsers { get; set; }    
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Borrowing> Borrowings { get; set; }

        // seeding
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action" },
                new Category { Id = 2, Name = "SciFi" },
                new Category { Id = 3, Name = "History" }
             );

            builder.Entity<Product>().HasData(
                new Product {
                    Id = 1,
                    Title = "HarryPotter part 1",
                    Description = "abcxyz",
                    Author = "J.K.Rowling",
                    ISBN = "HP000001",
                    Price = 10000,
                    Amount = 10,
                    CategoryId = 1,
                },
                new Product
                {
                    Id = 2,
                    Title = "HarryPotter part 2",
                    Description = "abcxyzmng",
                    Author = "J.K.Rowling",
                    ISBN = "HP000002",
                    Price = 12000,
                    Amount = 5,
                    CategoryId = 1,
                }
            );
        }

    }
}
