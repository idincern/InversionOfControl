using System;
using System.Collections.Generic;

public class DAL : IDAL
{
    public List<Product> GetProducts()
    {
        // Simulated database call to retrieve products
        return new List<Product>
        {
            new Product { Id = 1, Name = "Product A", Price = 10.99m },
            new Product { Id = 2, Name = "Product B", Price = 20.50m },
            new Product { Id = 3, Name = "Product C", Price = 5.75m }
        };
    }
}
