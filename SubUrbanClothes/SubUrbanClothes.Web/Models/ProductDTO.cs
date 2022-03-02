using SubUrbanClothes.Database;

namespace SubUrbanClothes.Web.Models
{
    public class ProductDTO
    {
        public Product product { get; set; }
        public List<Brand> Brands { get; set; }
        public List<Category> Categories { get; set; }

        public ProductDTO()
        {

        }

        public ProductDTO(List<Brand> brands, List<Category> categories)
        {
            this.Brands = brands;
            this.Categories = categories;
        }

        public ProductDTO(Product product, List<Brand> brands, List<Category> categories)
        {
            this.product = product;
            this.Brands = brands;
            this.Categories = categories;
        }
    }
}
