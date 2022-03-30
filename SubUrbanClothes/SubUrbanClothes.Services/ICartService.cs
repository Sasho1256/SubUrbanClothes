using SubUrbanClothes.Database;
using SubUrbanClothes.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubUrbanClothes.Services
{
    public interface ICartService : IDisposable
    {
        public void AddToCart(int id);
        public void Dispose();
        public string GetCartId();
        public List<CartItem> GetCartItems();
    }
}
