using SubUrbanClothes.Web.Models;
using SubUrbanClothes.Web.Services.Contracts;

namespace SubUrbanClothes.Web.Services
{
    public class BrandService : IBrandService
    {

        public void Create(Brand Brand)
        {
            if (string.IsNullOrEmpty(brand.BrandName) || string.IsNullOrWhiteSpace(brand.BrandName))
            {
                throw new ArgumentException("Incorrect input for brand name.");
            }
            List<Brand> brands = database.Brands.ToList();
            if (!brands.Exists(d => d.BrandName == brand.BrandName))
            {
                database.Add(brand);
            }
            database.SaveChanges();
        }

        public List<Brand> GetAll()
        {
            List<Brand> brands = database.Directors.ToList();
            return brands;
        }
    }
}
