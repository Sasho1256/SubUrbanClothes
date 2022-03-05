using SubUrbanClothes.Database.Models;

namespace SubUrbanClothes.Web.Models
{
    public class ProductViewModel
    {
        public Product product { get; set; }
        public List<Brand> Brands { get; set; }
        public List<Category> Categories { get; set; }
        public List<Color> Colors { get; set; }

        public ProductViewModel()
        {

        }

        public ProductViewModel(List<Brand> brands, List<Category> categories, List<Color> colors)
        {
            this.Brands = brands;
            this.Categories = categories;
            this.Colors = colors;
        }

        public ProductViewModel(Product product, List<Brand> brands, List<Category> categories, List<Color> colors)
        {
            this.product = product;
            this.Brands = brands;
            this.Categories = categories;
            this.Colors = colors;
        }
    }
}
