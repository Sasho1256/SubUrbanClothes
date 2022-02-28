using Microsoft.AspNetCore.Http;
using SubUrbanClothes.Database;
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
        IHttpContextAccessor contextAccessor;

        public CartService(SubUrbanClothesDbContext _db)
        {
            this._db = _db;
            this.contextAccessor = new HttpContextAccessor();
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
                    Product = _db.Products.SingleOrDefault(
                   p => p.Id == id),
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
    }
}
