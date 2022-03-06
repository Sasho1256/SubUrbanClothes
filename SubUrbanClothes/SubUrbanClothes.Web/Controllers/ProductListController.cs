using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SubUrbanClothes.Database;

namespace SubUrbanClothes.Web.Controllers
{
    public class ProductListController : Controller
    {
        private readonly SubUrbanClothesDbContext db;

        public ProductListController(SubUrbanClothesDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View(db.Products.Include(product => product.Brand).Include(product => product.Color).Include(product => product.Category).Include(product => product.Gender).ToList());
        }
    }
}
