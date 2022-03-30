using SubUrbanClothes.Database;
using SubUrbanClothes.Database.Models;

namespace SubUrbanClothes.Web.Services.Contracts
{
    interface IBrandService
    {   
        void Create(Brand brand);
        List<Brand> GetAll();
    }
}
