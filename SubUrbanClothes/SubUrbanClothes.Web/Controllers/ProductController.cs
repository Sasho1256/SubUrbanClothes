using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SubUrbanClothes.Database;
using SubUrbanClothes.Database.Models;
using SubUrbanClothes.Services.Contracts;

namespace SubUrbanClothes.Web.Controllers
{
    public class ProductController : Controller
    {
        private IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        public IActionResult Index(int id)
        {
            return View(productService.GetById(id));
        }

        public IActionResult Delete(int id)
        {
            productService.Delete(id);
            return Redirect("/");
        }
    }
}
