using System;
using System.Collections.Generic;


namespace DapperInClass.Products
{
    public interface IProductRepository
    {
        IEnumerable<Products> GetAllProducts();
        void CreateProduct(string name, double price, int categoryID);
    }

} 
    
