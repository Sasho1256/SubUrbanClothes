using Microsoft.AspNetCore.Mvc;

namespace SubUrbanClothes.Web.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
