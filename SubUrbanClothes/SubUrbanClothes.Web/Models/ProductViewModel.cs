using SubUrbanClothes.Database.Models;

namespace SubUrbanClothes.Web.Models
{
    public class ProductViewModel
    {
        public ProductViewModel()
        {

        }
        public ProductViewModel(string name, decimal price, string size, string productType, string thumbnailURL, string brand, string color, string category, string gender)
        {
            Name = name;
            Price = price;
            Size = size;
            ProductType = productType;
            ThumbnailURL = thumbnailURL;
            Brand = brand;
            Color = color;
            Category = category;
            Gender = gender;
        }

        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Size { get; set; }
        public string ProductType { get; set; }
        public string ThumbnailURL { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }
        public string Category { get; set; }
        public string Gender { get; set; }

    }
}
