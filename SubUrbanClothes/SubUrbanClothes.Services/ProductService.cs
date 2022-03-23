using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

    public List<Product> GetAllProducts()
    {
        return database.Products.ToList();
    }
    public Product ProductInfo(Product product)
    {
        product.Brand = database.Brands.FirstOrDefault(g => g.Id == product.Brand_Id);
        product.Color = database.Colors.FirstOrDefault(d => d.Id == product.Color_Id);

        return product;
    }
    public Product ProductInfoInCart(Product product)
    {
        product.Brand = database.Brands.FirstOrDefault(g => g.Id == product.Brand_Id);
        product.Color = database.Colors.FirstOrDefault(d => d.Id == product.Color_Id);

        return product;
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

    public void Edit(Product updatedProduct, string productId)
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

    public void Delete(string productId)
    {
        Product productToDelete = GetById(productId);
        List<Product> productsToDelete = database.Products.Where(fu => fu.Brand_Id == productToDelete.Id).ToList();

        database.Products.RemoveRange(productsToDelete);
        database.Products.Remove(productToDelete);
        database.SaveChanges();
    }

    public Product GetById(string productId)
    {
        Product product = database.Products.FirstOrDefault(f => f.Id == int.Parse(productId));
        return product;
    }
}
