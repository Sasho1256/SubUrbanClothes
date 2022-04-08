using SubUrbanClothes.Database;
using SubUrbanClothes.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubUrbanClothes.Services.Contracts
{
    public interface ICartService : IDisposable
    {
        public void CreateCart(string cartId);
        public void AddToCart(int id, string cartId);
        public void UpdateCart(List<CartItem> newCartItems, string cartId);
        public void Dispose();
        public List<CartItem> GetCartItems(string cartId);
        public decimal GetTotal(string cartId);
        public string GetCartIdByUser(string userName);
    }
}
