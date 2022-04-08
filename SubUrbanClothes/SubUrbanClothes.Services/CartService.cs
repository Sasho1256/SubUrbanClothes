using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SubUrbanClothes.Database;
using SubUrbanClothes.Database.Models;
using SubUrbanClothes.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SubUrbanClothes.Services
{
    public class CartService : ICartService
    {
        public string ShoppingCartId { get; set; }

        private SubUrbanClothesDbContext _db;

        public CartService(SubUrbanClothesDbContext _db)
        {
            this._db = _db;
        }

        public void CreateCart(string cartId)
        {
            Cart cart = new Cart()
            {
                Id = cartId
            };

            _db.ShoppingCarts.Add(cart);
            _db.SaveChanges();
        }

        public void AddToCart(int id, string cartId)
        {
            // Retrieve the product from the database.           
            ShoppingCartId = cartId;

            var cartItem = _db.ShoppingCartItems.SingleOrDefault(
                c => c.CartId == ShoppingCartId
                && c.ProductId == id);
            if (cartItem == null)
            {
                // Create a new cart item if no cart item exists. 
                cartItem = new CartItem
                {
                    ItemId = Guid.NewGuid().ToString(),
                    ProductId = id,
                    CartId = ShoppingCartId,
                    Product = _db.Products.SingleOrDefault(p => p.Id == id),
                    Quantity = 1,
                    DateCreated = DateTime.Now
                };

                _db.ShoppingCartItems.Add(cartItem);
            }
            else
            {
                // If the item does exist in the cart,                  
                // then add one to the quantity.                 
                cartItem.Quantity++;
            }
            _db.SaveChanges();
        }

        public void UpdateCart(List<CartItem> newCartItems, string cartId)
        {
            List<CartItem> old = GetCartItems(cartId);
            List<string> toRemove = new List<string>();
            for (int i = 0; i < newCartItems.Count; i++)
            {
                if (newCartItems[i].Quantity<=0)
                {
                    var item = _db.ShoppingCartItems.First(sci => sci.ItemId == newCartItems[i].ItemId);
                    _db.ShoppingCartItems.Remove(item);
                }
                else if (newCartItems[i].Quantity != old[i].Quantity)
                {
                    var a = _db.ShoppingCartItems.First(sci => sci.ItemId == newCartItems[i].ItemId);
                    _db.ShoppingCartItems.First(sci => sci.ItemId == newCartItems[i].ItemId).Quantity = newCartItems[i].Quantity;
                }
            }

            _db.SaveChanges();
        }

        public void Dispose()
        {
            //if (_db != null)
            //{
            //    _db.Dispose();
            //    _db = null;
            //}
        }

        public List<CartItem> GetCartItems(string cartId)
        {
            ShoppingCartId = cartId;

            return _db.ShoppingCartItems.Include(cartItem => cartItem.Product).Include(cartItem => cartItem.Product.Color).Where(
                c => c.CartId == ShoppingCartId).ToList();
        }

        public decimal GetTotal(string cartId)
        {
            ShoppingCartId = cartId;
            // Multiply product price by quantity of that product to get        
            // the current price for each of those products in the cart.  
            // Sum all product price totals to get the cart total.   
            decimal? total = decimal.Zero;
            total = (decimal?)(from cartItems in _db.ShoppingCartItems
                               where cartItems.CartId == ShoppingCartId
                               select (int?)cartItems.Quantity *
                               cartItems.Product.Price).Sum();
            return total ?? decimal.Zero;
        }

        public string GetCartIdByUser(string userName)
        {

            return _db.ShoppingCarts.Where(c => c.User.UserName == userName).FirstOrDefault().Id ?? "";
        }
    }
}
