using System.ComponentModel.DataAnnotations.Schema;

namespace SubUrbanClothes.Database
{
    public class Shoe
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public double Size { get; set; }

        [ForeignKey("Brand")]
        [Column("Brand_Id")]
        public int? Brand_Id { get; set; }
        public Brand Brand { get; set; }

        [ForeignKey("Color")]
        [Column("Color_Id")]
        public int? Color_Id { get; set; }
        public Color Color { get; set; }

        [ForeignKey("Category")]
        [Column("Category_Id")]
        public int? Category_Id { get; set; }
        public Category Category { get; set; }

        [ForeignKey("Gender")]
        [Column("Gender_Id")]
        public int? Gender_Id { get; set; }
        public Gender Gender { get; set; }
    }
}
