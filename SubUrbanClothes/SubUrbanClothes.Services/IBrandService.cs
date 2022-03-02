using SubUrbanClothes.Web.Models;

namespace SubUrbanClothes.Web.Services.Contracts
{
    interface IBrandService
    {
        /// <summary>
        /// Adds <paramref name="brand"/> to the database if a brand with the same name doesn't already exist. 
        /// </summary>
        /// <param name="brand"></param>
        void Create(Brand brand);

        /// <summary>
        /// Returns a list with all the brands in the database.
        /// </summary>
        /// <returns></returns>
        List<Brand> GetAll();
    }
}
