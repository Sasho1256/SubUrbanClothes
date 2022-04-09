using Microsoft.AspNetCore.Mvc;
using Stripe;
using SubUrbanClothes.Database.Models;
using SubUrbanClothes.Services.Contracts;
using SubUrbanClothes.Web.Models;

namespace SubUrbanClothes.Web.Controllers
{
    public class CartController : Controller
    {
        public const string CartSessionKey = "CartId";

        private PaymentModel model;

        private ICartService shoppingCartService;
        private readonly ChargeService chargeService;

        public CartController(ICartService shoppingCartService, ChargeService chargeService)
        {
            this.shoppingCartService = shoppingCartService;
            this.chargeService = chargeService;
        }

        public IActionResult Index()
        {
            var cartItems = shoppingCartService.GetCartItems(GetCartId());
            return View(cartItems);
        }

        public IActionResult AddToCart(Database.Models.Product product)
        {
            shoppingCartService.AddToCart(product.Id, GetCartId());
            return RedirectToAction("Index");
        }

        public IActionResult UpdateCart(List<CartItem> newCartItems)
        {
            shoppingCartService.UpdateCart(newCartItems, GetCartId());
            return RedirectToAction("Index");
        }

        public string GetCartId()
        {
            var session = this.HttpContext.Session.GetString(CartSessionKey);
            var userName = this.User.Identity.Name;

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

        [HttpGet]
        public IActionResult Checkout()
        {
            if (model == null)
            {
                var items = this.shoppingCartService.GetCartItems(GetCartId());
                var price = items.Select(x => x.Price).Sum();
                model = new PaymentModel()
                {
                    ProductName = string.Join(" ", items.Select(x => x.Product.Name).ToList()),
                    Amount = (decimal)price,
                    Company = "SubUrbanClothes",
                    Description = "",
                    Label = $"Pay ${price}"
                };
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Checkout(string stripeToken, string stripeEmail)
        {
            if (model == null)
            {
                var items = this.shoppingCartService.GetCartItems(GetCartId());
                var price = items.Select(x => x.Price).Sum();
                model = new PaymentModel()
                {
                    ProductName = string.Join(" ", items.Select(x => x.Product.Name).ToList()),
                    Amount = (decimal)price,
                    Company = "SubUrbanClothes",
                    Description = "",
                    Label = $"Pay ${price}"
                };
            }
            Dictionary<string, string> Metadata = new Dictionary<string, string>();
            Metadata.Add("Product", model.ProductName);
            Metadata.Add("Quantity", "1");

            var options = new ChargeCreateOptions
            {
                Amount = (long)(model.Amount * 100),
                Currency = "USD",
                Description = model.Description,
                Source = stripeToken,
                ReceiptEmail = stripeEmail,
                Metadata = Metadata
            };

            var charge = this.chargeService.Create(options);

            return RedirectToAction("Index", "Transaction");
            //return RedirectToAction("/");
        }
    }
}
