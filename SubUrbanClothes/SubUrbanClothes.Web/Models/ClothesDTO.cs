namespace SubUrbanClothes.Web.Models
{
    public class ClothesDTO
    {
        public Clothes clothes { get; set; }
        public List<Brand> Brand { get; set; }
        public List<Category> Category { get; set; }

        public ClothesDTO()
        {

        }

        public ClothesDTO(List<Brand> brands, List<Category> categories)
        {
            this.Brands = brands;
            this.Categories = categories;
        }

        public ClothesDTO(Shoe shoe, List<Brand> brands, List<Category> categories)
        {
            this.shoe = shoe;
            this.Brands = brands;
            this.Categories = categories;
        }
    }
}
