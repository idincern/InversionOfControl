using System;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjectionSample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Setup Dependency Injection
            var serviceProvider = new ServiceCollection()
                .AddTransient<IDAL, DAL>()
                .AddTransient<BL>()
                .BuildServiceProvider();

            // Resolve BL from the DI container
            var bl = serviceProvider.GetService<BL>();

            // Use BL to get products
            var products = bl?.GetProducts();

            // Example usage: Display products
            Console.WriteLine("Products:");
            if (products != null)
                foreach (var product in products)
                {
                    Console.WriteLine($"- {product.Name}: ${product.Price}");
                }
        }
    }
}