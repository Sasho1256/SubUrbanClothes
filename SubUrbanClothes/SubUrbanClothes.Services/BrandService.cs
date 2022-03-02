using SubUrbanClothes.Database;
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
            if (string.IsNullOrEmpty(brand.Name) || string.IsNullOrWhiteSpace(brand.Name))
            {
                throw new ArgumentException("Incorrect input for brand name.");
            }
            List<Brand> brands = database.Brands.ToList();
            if (!brands.Exists(d => d.Name == brand.Name))
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
