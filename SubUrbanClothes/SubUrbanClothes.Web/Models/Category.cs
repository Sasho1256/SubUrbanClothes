namespace SubUrbanClothes.Web.Models
{
    public partial class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Shoe> Shoes { get; set; }
    }
}
