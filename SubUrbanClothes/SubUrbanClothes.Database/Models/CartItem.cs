using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubUrbanClothes.Database.Models
{
    public class CartItem
    {
        [Key]
        [Column("Item_Id")]
        public string ItemId { get; set; }
        
        [Column("Cart_Id")]
        public string CartId { get; set; }
        public Cart Cart { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public System.DateTime DateCreated { get; set; }
        
        [ForeignKey("Product")]
        [Column("Product_Id")]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
