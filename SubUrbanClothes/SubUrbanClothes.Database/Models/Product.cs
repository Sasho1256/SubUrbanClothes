using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SubUrbanClothes.Database.Models
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }

        [Range (0, int.MaxValue, ErrorMessage = "Price must be a positive number.")]
        public double Price { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Size must be a positive number.")]
        public double Size { get; set; }
        public string ProductType { get; set; }

        public string ThumbnailURL { get; set; }

        [ForeignKey("Brand")]
        [Column("Brand_Id")]
        public int? BrandId { get; set; }
        public Brand Brand { get; set; }

        [ForeignKey("Color")]
        [Column("Color_Id")]
        public int? ColorId { get; set; }
        public Color Color { get; set; }

        [ForeignKey("Category")]
        [Column("Category_Id")]
        public int? CategoryId { get; set; }
        public Category Category { get; set; }

        [ForeignKey("Gender")]
        [Column("Gender_Id")]
        public int? GenderId { get; set; }
        public Gender Gender { get; set; }
    }
}
