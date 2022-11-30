using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SubUrbanClothes.Database.Models;

namespace SubUrbanClothes.Database
{
    public class SubUrbanClothesDbContext : IdentityDbContext
    {
        private const string role1 = "administrator";
        private const string role2 = "client";
        public SubUrbanClothesDbContext(DbContextOptions<SubUrbanClothesDbContext> options)
            : base(options)
        {
        }
        public SubUrbanClothesDbContext()
        {

        }

        //dbsets
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<CartItem> ShoppingCartItems { get; set; }
        public DbSet<Cart> ShoppingCarts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //fluent api
            builder.Entity<Category>()
                .HasIndex(x => x.Category_Name)
                .IsUnique();

            builder.Entity<Gender>()
                .HasIndex(x => x.Gender_Name)
                .IsUnique();

            builder.Entity<Brand>()
                .HasIndex(x => x.Brand_Name)
                .IsUnique();

            builder.Entity<Color>()
                .HasIndex(x => x.Color_Name)
                .IsUnique();

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole()
                {
                    Name = role1,
                    NormalizedName = role1.ToUpper(),
                },
                new IdentityRole()
                {
                    Name = role2,
                    NormalizedName = role2.ToUpper(),
                }
            );
        }
    }
}