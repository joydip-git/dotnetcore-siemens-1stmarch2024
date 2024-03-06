using PMSApp.DAL;
using PMSApp.Data;
using Microsoft.Extensions.DependencyInjection;
using PMSApp.Entities;
using PMSApp.BL;

namespace PMSApp
{
    internal class Program
    {
        static IServiceProvider ConfigureServiceProvider()
        {
            //configure service provider here
            var collectionOfServices = new ServiceCollection();
            collectionOfServices.AddSingleton<IInventory, Inventory>();

            var provider =
                collectionOfServices
                .AddSingleton<IInventory, Inventory>()
                .AddSingleton<IDataAccess<Product>, ProductDao>()
                .AddSingleton<IDataAccess<Category>, CategoryDao>()
                .AddSingleton<IProductBusinessComponent,ProductBO>()
                .BuildServiceProvider();

            return provider;
        }
        static void Main()
        {
            var provider = ConfigureServiceProvider();
            
            try
            {
                var productBo = provider.GetRequiredService<IProductBusinessComponent>();

                var products = productBo.FetchAll();
                foreach (var product in products)
                {
                    Console.WriteLine(product.Name);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
