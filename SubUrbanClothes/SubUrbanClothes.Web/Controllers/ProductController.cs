using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SubUrbanClothes.Database;
using SubUrbanClothes.Database.Models;
using SubUrbanClothes.Services.Contracts;
using SubUrbanClothes.Web.Models;

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

        [HttpGet]
        public IActionResult Create()
        {
            ProductViewModel productVM = new ProductViewModel();
            return View(productVM);
        }
        [HttpPost]
        public IActionResult Create(ProductViewModel productVM)
        {
            var product = ConvertVMToProduct(productVM);
            var brand = productVM.Brand;
            var color = productVM.Color;
            var caregory = productVM.Category;
            var gender = productVM.Gender;

            productService.Create(product, brand, color, caregory, gender);
            return Redirect("/");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var product = productService.GetById(id);
            if (product != null)
            {
                ProductViewModel productVM = new ProductViewModel()
                {
                    ProductId = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    Size = product.Size,
                    ProductType = product.ProductType,
                    ThumbnailURL = product.ThumbnailURL,
                    Brand = product.Brand.Brand_Name,
                    Color = product.Color.Color_Name,
                    Category = product.Category.Category_Name,
                    Gender = product.Gender.Gender_Name,
                };
                return View(productVM);
            }
            return Redirect("/");
        }
        [HttpPost]
        public IActionResult Update(ProductViewModel productVM)
        {
            var product = ConvertVMToProduct(productVM);
            var productId = productVM.ProductId;
            var brand = productVM.Brand;
            var color = productVM.Color;
            var caregory = productVM.Category;
            var gender = productVM.Gender;

            productService.Update(product, brand, color, caregory, gender, productId);
            return Redirect("/");
        }

        public IActionResult Delete(int id)
        {
            productService.Delete(id);
            return Redirect("/");
        }

        public Product ConvertVMToProduct(ProductViewModel productVM)
        {
            Product product = new Product()
            {
                Name = productVM.Name,
                Price = productVM.Price,
                Size = productVM.Size,
                ProductType = productVM.ProductType,
                ThumbnailURL = productVM.ThumbnailURL,
            };
            return product;
        }
    }
}
