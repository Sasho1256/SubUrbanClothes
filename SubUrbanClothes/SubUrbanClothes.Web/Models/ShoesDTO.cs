namespace SubUrbanClothes.Web.Models
{
    public class ShoesDTO
    {
        public Shoe shoe { get; set; }
        public List<Brand> Brand { get; set; }
        public List<Category> Category { get; set; }

        public ShoesDTO()
        {

        }

        public ShoesDTO(List<Brand> brands, List<Category> categories)
        {
            this.Brands = brands;
            this.Categories = categories;
        }

        public ShoesDTO(Shoe shoe, List<Brand> brands, List<Category> categories)
        {
            this.shoe = shoe;
            this.Brands = brands;
            this.Categories = categories;
        }
    }
}
