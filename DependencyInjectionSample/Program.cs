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
                .AddTransient<IDAL, DAL>() // Adds a transient service of the type specified in IDAL with an implementation type specified in DAL to the specified IServiceCollection.
                .AddTransient<BL>() // Adds a transient service of the type specified in BL to the specified IServiceCollection.
                .BuildServiceProvider(); // Creates a ServiceProvider containing services from the provided IServiceCollection.

            // Resolve BL from the DI container
            var bl = serviceProvider.GetService<BL>(); // Get service of type BL from the IServiceProvider.

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