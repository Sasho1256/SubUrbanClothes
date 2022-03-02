﻿using Microsoft.AspNetCore.Mvc;
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
            return View(db.Products.ToList());
        }
    }
}
