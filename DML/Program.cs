using FirstEntityFramework.Data;
using FirstEntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection.Metadata;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FirstEntityFramework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            //Retrieve all categories from the production.categories table.
           var ctegory=db.Products.Include(c=>c.Category).ToList();
            foreach (var c in ctegory)
            {
                Console.WriteLine(c.Category.CategoryName);
            }
            // Retrieve the first product from the production.products table.
            var product = db.Products.FirstOrDefault();
            if (product == null)
            {
                Console.WriteLine("Not found");
            }else
            {
                Console.WriteLine($"ProductId : {product.ProductId} , ProductName : {product.ProductName}");
            }
            //Retrieve a specific product from the production.products table by ID
            var products = db.Products.Find(1);
            Console.WriteLine(products);
            //Retrieve all products from the production.products table with a certain model year.
            var Productss = db.Products.Where(m=>m.ModelYear==2016).ToList();
            foreach (var p in Productss) 
            {
                Console.WriteLine($"ProductId : {p.ProductId} , ProductName : {p.ProductName} , Model year {p.ModelYear}");
            }
            //Retrieve a specific customer from the sales.customers table by ID.
            var customer=db.Customers.FirstOrDefault(e=>e.CustomerId==1);
            Console.WriteLine($"CustomerName : {customer.FirstName}  {customer.LastName}");
            //Retrieve a list of product names and their corresponding brand names.
            var Brands = db.Products.Include(b =>b.Brand).Select(b => new { b.ProductId, b.ProductName, b.Brand,b.BrandId });
            foreach(var b in Brands)
            {
                Console.WriteLine($"ProductId : {b.ProductId} , ProductName : {b.ProductName} , BrandId : {b.BrandId} ,BrandName :{b.Brand.BrandName}");
            }
            //Count the number of products in a specific category.
            var Category=db.Products.ToList();
            Console.WriteLine($"Count of Product{  Category.Count(c=>c.CategoryId==7)}");
            //Calculate the total list price of all products in a specific category
            var category = db.Products.Where(c=>c.CategoryId==7);
            Console.WriteLine($"Sum of ListPrice {category.Sum(s=>s.ListPrice)}");
            //Calculate the average list price of products.
            var list = db.Products;
            Console.WriteLine($"Average : {list.Average(l=>l.ListPrice)}");





        }
    }
}
