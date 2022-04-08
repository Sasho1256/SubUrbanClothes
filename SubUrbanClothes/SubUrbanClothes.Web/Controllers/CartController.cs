using Microsoft.AspNetCore.Mvc;
using SubUrbanClothes.Database;
using SubUrbanClothes.Database.Models;
using SubUrbanClothes.Services.Contracts;

namespace SubUrbanClothes.Web.Controllers
{
    public class CartController : Controller
    {
        public const string CartSessionKey = "CartId";

        ICartService shoppingCartService;
        private IHttpContextAccessor contextAccessor;

        public CartController(ICartService shoppingCartService, IHttpContextAccessor contextAccessor)
        {
            this.shoppingCartService = shoppingCartService;
            this.contextAccessor = contextAccessor;
        }

        public IActionResult Index()
        {
            var cartItems = shoppingCartService.GetCartItems(GetCartId());
            return View(cartItems);
        }

        public IActionResult AddToCart(Product product)
        {
            shoppingCartService.AddToCart(product.Id, GetCartId());
            return RedirectToAction("Index");
        }

        //TODO:
        // extract to controller                                                                DONE
        // if user is logged, get cart from db                                                  DONE
        // if no user is logged, get cart from session                                          DONE
        // if no user is logged and there's no cart in session, generate new cart in session    DONE
        public string GetCartId()
        {
            var session = this.HttpContext.Session.GetString(CartSessionKey);
            var userName = this.User.Identity.Name;
            //var session = HttpContext.Current.Session[CartSessionKey];
            //var user = HttpContext.Current.User.Identity.Name;

            if (!string.IsNullOrWhiteSpace(userName))
            {
                //contextAccessor.HttpContext.Session.SetString(CartSessionKey, user);
                return shoppingCartService.GetCartIdByUser(userName);
            }

            if (session == null)
            {
                // Generate a new random GUID using System.Guid class.     
                Guid tempCartId = Guid.NewGuid();
                this.HttpContext.Session.SetString(CartSessionKey, tempCartId.ToString());
                shoppingCartService.CreateCart(tempCartId.ToString());
            }

            return this.HttpContext.Session.GetString(CartSessionKey);
        }
    }
}
