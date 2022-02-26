using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

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
        public DbSet<Clothing> Clothes { get; set; }
        public DbSet<Shoe> Shoes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Color> Colors { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //fluent api
            builder.Entity<Category>()
                .HasIndex(x => x.Name)
                .IsUnique();

            builder.Entity<Gender>()
                .HasIndex(x => x.Name)
                .IsUnique();

            builder.Entity<Brand>()
                .HasIndex(x => x.Name)
                .IsUnique();

            builder.Entity<Color>()
                .HasIndex(x => x.Name)
                .IsUnique();
        }
    }
}