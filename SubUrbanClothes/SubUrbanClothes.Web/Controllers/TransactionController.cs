﻿using Microsoft.AspNetCore.Mvc;
using Stripe;

namespace SubUrbanClothes.Web.Controllers
{
    public class TransactionController : Controller
    {
        private readonly ChargeService chargeService;

        public TransactionController(ChargeService chargeService)
        {
            this.chargeService = chargeService;
        }

        public IActionResult Index()
        {
            return View(this.chargeService.List().ToList());
        }
    }
}
