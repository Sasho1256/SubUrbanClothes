using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SubUrbanClothes.Database.Models;

namespace SubUrbanClothes.Services.Contracts
{
    interface IProductService
    {
        List<Product> GetAllProducts();
        Product ProductInfo(Product product);
        Product ProductInfoInCart(Product product);
        void Create(Product product);
        void Edit(Product updatedProduct, string productId);
        void Delete(string productId);
        Product GetById(string productId);
    }
}