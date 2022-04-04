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
            return View();
        }

        public IActionResult AddToCart(int id)
        {
            shoppingCartService.AddToCart(id);
            return View();
        }
    }
}
