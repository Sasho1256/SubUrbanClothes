using Microsoft.AspNetCore.Mvc;
using SubUrbanClothes.Database;

namespace SubUrbanClothes.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly SubUrbanClothesDbContext db;

        public ProductController(SubUrbanClothesDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index(int id)
        {
            return View(db.Products.FirstOrDefault(x => x.Id == id));
        }
    }
}
