using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SubUrbanClothes.Database;
using SubUrbanClothes.Database.Models;

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
            return View(db.Products.Include(product => product.Brand).Include(product => product.Color).Include(product => product.Category).Include(product => product.Gender).SingleOrDefault(x => x.Id == id));
        }
    }
}
