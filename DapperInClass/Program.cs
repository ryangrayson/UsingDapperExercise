using System;
using System.Data;
using System.IO;
using DapperInClass.Products;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace DapperInClass
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");

            IDbConnection conn = new MySqlConnection(connString);

            var repo = new DapperDepartmentRepository(conn);

            var departments = repo.GetAllDepartments();
            
            foreach (var dept in departments)
            {
                Console.WriteLine($"{dept.DepartmentID} {dept.Name}");
            }

            var prod = new DapperProductRepository(conn);
            var products = prod.GetAllProducts();

            foreach (var product in products)
            {
                Console.WriteLine($"Product: {product.Name}\nPrice: {product.Price}\nCategory ID: {product.CategoryID}\n--------------------");
            }
        }
    }
}
