using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SubUrbanClothes.Database;
using SubUrbanClothes.Database.Models;
using SubUrbanClothes.Services.Contracts;


public class ProductService : IProductService
{
    private SubUrbanClothesDbContext database;

    public ProductService(SubUrbanClothesDbContext database)
    {
        this.database = database;
    }

    public void Create(Product product, string brandName, string colorName, string caregoryName, string genderName)
    {
        var brand = database.Brands.FirstOrDefault(b => b.Brand_Name == brandName);
        var color = database.Colors.FirstOrDefault(c => c.Color_Name == colorName);
        var caregory = database.Categories.FirstOrDefault(ca => ca.Category_Name == caregoryName);
        var gender = database.Genders.FirstOrDefault(g => g.Gender_Name == genderName);

        if (brand == null)
        {
            database.Brands.Add(new Brand() { Brand_Name = brandName });
            database.SaveChanges();
            brand = database.Brands.FirstOrDefault(b => b.Brand_Name == brandName);
            product.Brand_Id = brand.Id;
        }
        else
        {
            product.Brand_Id = brand.Id;
        }

        if (color == null)
        {
            database.Colors.Add(new Color() { Color_Name = colorName });
            database.SaveChanges();
            color = database.Colors.FirstOrDefault(c => c.Color_Name == colorName);
            product.Color_Id = color.Id;
        }
        else
        {
            product.Color_Id = color.Id;
        }

        if (caregory == null)
        {
            database.Categories.Add(new Category() { Category_Name = caregoryName });
            database.SaveChanges();
            caregory = database.Categories.First(ca => ca.Category_Name == caregoryName);
            product.Category_Id = caregory.Id;
        }
        else
        {
            product.Category_Id = caregory.Id;
        }

        if (gender == null)
        {
            database.Genders.Add(new Gender() { Gender_Name = genderName });
            database.SaveChanges();
            gender = database.Genders.First(g => g.Gender_Name == genderName);
            product.Gender_Id = gender.Id;
        }
        else
        {
            product.Gender_Id = gender.Id;
        }


        database.Products.Add(product);
        database.SaveChanges();
    }

    public void Update(Product newProduct, string brandName, string colorName, string caregoryName, string genderName, int productId)
    {
        Product product = GetById(productId);

        if (product != null)
        {
            product.Name = newProduct.Name;
            product.Price = newProduct.Price;
            product.Size = newProduct.Size;
            product.ProductType = newProduct.ProductType;
            product.ThumbnailURL = newProduct.ThumbnailURL;

            var brand = database.Brands.FirstOrDefault(b => b.Brand_Name == brandName);
            var color = database.Colors.FirstOrDefault(c => c.Color_Name == colorName);
            var caregory = database.Categories.FirstOrDefault(ca => ca.Category_Name == caregoryName);
            var gender = database.Genders.FirstOrDefault(g => g.Gender_Name == genderName);

            if (brand == null)
            {
                database.Brands.Add(new Brand() { Brand_Name = brandName });
                database.SaveChanges();
                brand = database.Brands.FirstOrDefault(b => b.Brand_Name == brandName);
                product.Brand_Id = brand.Id;
            }
            else
            {
                product.Brand_Id = brand.Id;
            }

            if (color == null)
            {
                database.Colors.Add(new Color() { Color_Name = colorName });
                database.SaveChanges();
                color = database.Colors.FirstOrDefault(c => c.Color_Name == colorName);
                product.Color_Id = color.Id;
            }
            else
            {
                product.Color_Id = color.Id;
            }

            if (caregory == null)
            {
                database.Categories.Add(new Category() { Category_Name = caregoryName });
                database.SaveChanges();
                caregory = database.Categories.First(ca => ca.Category_Name == caregoryName);
                product.Category_Id = caregory.Id;
            }
            else
            {
                product.Category_Id = caregory.Id;
            }

            if (gender == null)
            {
                database.Genders.Add(new Gender() { Gender_Name = genderName });
                database.SaveChanges();
                gender = database.Genders.First(g => g.Gender_Name == genderName);
                product.Gender_Id = gender.Id;
            }
            else
            {
                product.Gender_Id = gender.Id;
            }

            database.Products.Update(product);
            database.SaveChanges();
        }
    }

    public void Delete(int productId)
    {
        Product productToDelete = GetById(productId);

        if (productToDelete != null)
        {
            database.Products.Remove(productToDelete);
            database.SaveChanges();
        }
    }

    public Product GetById(int productId)
    {
        Product product = database.Products.Include(product => product.Brand).Include(product => product.Color).Include(product => product.Category).Include(product => product.Gender).SingleOrDefault(x => x.Id == productId);
        return product;
    }
}
