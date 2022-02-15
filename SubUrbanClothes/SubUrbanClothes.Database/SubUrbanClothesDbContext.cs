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
    }
}