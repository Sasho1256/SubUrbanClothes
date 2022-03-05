using SubUrbanClothes.Database;
using SubUrbanClothes.Database.Models;
using SubUrbanClothes.Web.Services.Contracts;

namespace SubUrbanClothes.Web.Services
{
    public class BrandService : IBrandService
    {
        private SubUrbanClothesDbContext database;

        public BrandService(SubUrbanClothesDbContext database)
        {
            this.database = database;
        }

        public void Create(Brand brand)
        {
            if (string.IsNullOrEmpty(brand.Brand_Name) || string.IsNullOrWhiteSpace(brand.Brand_Name))
            {
                throw new ArgumentException("Incorrect input for brand name.");
            }
            List<Brand> brands = database.Brands.ToList();
            if (!brands.Exists(d => d.Brand_Name == brand.Brand_Name))
            {
                database.Add(brand);
            }
            database.SaveChanges();
        }

        public List<Brand> GetAll()
        {
            List<Brand> brands = database.Brands.ToList();
            return brands;
        }
    }
}
