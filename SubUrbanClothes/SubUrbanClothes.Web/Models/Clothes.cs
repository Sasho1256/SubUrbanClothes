namespace SubUrbanClothes.Web.Models
{
    public partial class Clothes
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int? YearRelease { get; set; }
        [ForeignKey("Brand")]
        [Column("brand_id")]
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        [ForeignKey("Type")]
        [Column("type_id")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
