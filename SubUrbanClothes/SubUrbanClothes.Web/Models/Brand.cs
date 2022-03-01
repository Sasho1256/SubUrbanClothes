namespace SubUrbanClothes.Web.Models
{
    public partial class Brand
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
        public List<Shoe> Shoes { get; set; }
    }
}
