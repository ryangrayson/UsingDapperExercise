using System;
using System.Collections.Generic;
using System.Data;
using Dapper;

namespace DapperInClass.Products
{
    public class DapperProductRepository : IProductRepository
    {
        private readonly IDbConnection _connection;

        //constructor - and will do some set up work for us
        public DapperProductRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        //Create Data
        public void CreateProduct(string name, double price, int categoryID)
        {
            _connection.Execute("INSERT INTO products (Name, Price, Category)" +
                                " VALUES (@name, @price, @categoryID);",
                                new { name = name, price = price, categoryID = categoryID });
        }

        //Read Data                        
        public IEnumerable<Products> GetAllProducts()
        {
            return _connection.Query<Products>("SELECT * FROM products;");
        }
                                

    }
}
