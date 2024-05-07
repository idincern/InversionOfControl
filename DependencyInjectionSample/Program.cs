using System;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjectionSample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Setup Dependency Injection
            // Singleton => Only one instance for the lifetime of the application
            // Scoped => Only one instance for each request
            // Transient => New instance each time an object is requested
            ServiceProvider serviceProvider = new ServiceCollection()
                .AddTransient<IDAL, DAL>() //  We added a transient service for IDAL implemented by DAL. => if IDAL is implemented via DI, a DAL object is created transient automatically.
                .AddTransient<BL>() // We added a transient service for BL.
                .BuildServiceProvider(); // The ServiceCollection is then used to build a ServiceProvider.
            //The ServiceProvider will now be able to provide instances of IDAL and BL when requested.

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