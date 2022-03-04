﻿using Microsoft.AspNetCore.Mvc;
using SubUrbanClothes.Database;
using SubUrbanClothes.Web.Models;
using System.Diagnostics;

namespace SubUrbanClothes.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SubUrbanClothesDbContext db;

        public HomeController(ILogger<HomeController> logger, SubUrbanClothesDbContext db)
        {
            _logger = logger;
            this.db = db;
        }

        public IActionResult Index()
        {
            return View(db.Products.ToList());
        }

        public IActionResult ContactUs()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}