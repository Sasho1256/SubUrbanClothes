using Microsoft.AspNetCore.Mvc;
using SubUrbanClothes.Database;
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
            //List<CartItem> cartItems = shoppingCartService.GetCartItems();
            //return View(cartItems);
            return View();
        }
    }
}
