using Microsoft.AspNetCore.Mvc;

namespace SubUrbanClothes.Web.Controllers
{
    public class ProductListController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
