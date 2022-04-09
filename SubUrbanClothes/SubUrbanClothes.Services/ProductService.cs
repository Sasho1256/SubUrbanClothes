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

    public void Create(Product product)
    {
        if (string.IsNullOrWhiteSpace(product.Name) || string.IsNullOrEmpty(product.Name))
        {
            throw new ArgumentException("Invalid input for name.");
        }
        if (string.IsNullOrWhiteSpace(product.ProductType) || string.IsNullOrEmpty(product.ProductType))
        {
            throw new ArgumentException("Invalid input for category.");
        }

        database.Products.Add(product);
        database.SaveChanges();
    }

    public void Edit(Product updatedProduct, int productId)
    {
        Product product = GetById(productId);

        if (string.IsNullOrWhiteSpace(updatedProduct.Name) || string.IsNullOrEmpty(updatedProduct.Name))
        {
            throw new ArgumentException("Invalid input for name.");
        }
        if (string.IsNullOrWhiteSpace(updatedProduct.ProductType) || string.IsNullOrEmpty(updatedProduct.ProductType))
        {
            throw new ArgumentException("Invalid input for category.");
        }

        product.Name = updatedProduct.Name;
        product.Price = updatedProduct.Price;
        product.Color = updatedProduct.Color;
        product.Brand = updatedProduct.Brand;
        product.Category = updatedProduct.Category;
        product.Size = updatedProduct.Size;

        database.Products.Update(product);
        database.SaveChanges();
    }

    public void Delete(int productId)
    {
        Product productToDelete = GetById(productId);

        database.Products.Remove(productToDelete);
        database.SaveChanges();
    }

    public Product GetById(int productId)
    {
        Product product = database.Products.Include(product => product.Brand).Include(product => product.Color).Include(product => product.Category).Include(product => product.Gender).SingleOrDefault(x => x.Id == productId);
        return product;
    }
}
