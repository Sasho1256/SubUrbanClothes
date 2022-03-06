using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SubUrbanClothes.Database.Models;

namespace SubUrbanClothes.Database
{
    public class SubUrbanClothesDbContext : IdentityDbContext
    {
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
        }
    }
}