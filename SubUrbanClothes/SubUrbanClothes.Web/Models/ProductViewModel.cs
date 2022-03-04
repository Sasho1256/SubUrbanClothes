using SubUrbanClothes.Database.Models;

namespace SubUrbanClothes.Web.Models
{
    public class ProductViewModel
    {
        public Product product { get; set; }
        public List<Brand> Brands { get; set; }
        public List<Category> Categories { get; set; }

        public ProductViewModel()
        {

        }

        public ProductViewModel(List<Brand> brands, List<Category> categories)
        {
            this.Brands = brands;
            this.Categories = categories;
        }

        public ProductViewModel(Product product, List<Brand> brands, List<Category> categories)
        {
            this.product = product;
            this.Brands = brands;
            this.Categories = categories;
        }
    }
}
