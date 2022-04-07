using Microsoft.AspNetCore.Http;
using SubUrbanClothes.Database;
using SubUrbanClothes.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SubUrbanClothes.Services
{
    public class CartService : ICartService
    {
        public string ShoppingCartId { get; set; }
        public const string CartSessionKey = "CartId";

        private SubUrbanClothesDbContext _db;
        private IHttpContextAccessor contextAccessor;

        public CartService(SubUrbanClothesDbContext _db, IHttpContextAccessor contextAccessor)
        {
            this._db = _db;
            this.contextAccessor = contextAccessor;
        }

        public void AddToCart(int id)
        {
            // Retrieve the product from the database.           
            ShoppingCartId = GetCartId();

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

        public void Dispose()
        {
            if (_db != null)
            {
                _db.Dispose();
                _db = null;
            }
        }

        public string GetCartId()
        {
            var session = contextAccessor.HttpContext.Session.GetString(CartSessionKey);
            var user = contextAccessor.HttpContext.User.Identity.Name;
            //var session = HttpContext.Current.Session[CartSessionKey];
            //var user = HttpContext.Current.User.Identity.Name;

            if (session == null)
            {
                if (!string.IsNullOrWhiteSpace(user))
                {
                    session = user;
                }
                else
                {
                    // Generate a new random GUID using System.Guid class.     
                    Guid tempCartId = Guid.NewGuid();
                    session = tempCartId.ToString();
                }
            }
            return session.ToString();
        }

        public List<CartItem> GetCartItems()
        {
            ShoppingCartId = GetCartId();

            return _db.ShoppingCartItems.Where(
                c => c.CartId == ShoppingCartId).ToList();
        }

        public decimal GetTotal()
        {
            ShoppingCartId = GetCartId();
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
    }
}
