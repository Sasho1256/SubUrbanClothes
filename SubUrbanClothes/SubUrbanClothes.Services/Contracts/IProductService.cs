using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SubUrbanClothes.Database.Models;

namespace SubUrbanClothes.Services.Contracts
{
    public interface IProductService
    {
        void Create(Product product, string brandName, string colorName, string caregoryName, string genderName);   //DONE
        void Update(Product newProduct, string brandName, string colorName, string caregoryName, string genderName, int productId);                                                           //TODO!!!
        void Delete(int productId);                                                                                 //DONE
        Product GetById(int productId);                                                                             //DONE
    }
}