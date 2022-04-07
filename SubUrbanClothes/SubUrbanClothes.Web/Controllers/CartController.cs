using Microsoft.AspNetCore.Mvc;
using SubUrbanClothes.Database;
using SubUrbanClothes.Database.Models;
using SubUrbanClothes.Services;

namespace SubUrbanClothes.Web.Controllers
{
    public class CartController : Controller
    {
        ICartService shoppingCartService;

        public CartController(ICartService shoppingCartService)
        {
            this.shoppingCartService = shoppingCartService;
        }

        public IActionResult Index()
        {
            var cartItems = shoppingCartService.GetCartItems();
            return View(cartItems);
        }

        public IActionResult AddToCart(Product product)
        {
            shoppingCartService.AddToCart(product.Id);
            return RedirectToAction("Index");
        }
    }
}
