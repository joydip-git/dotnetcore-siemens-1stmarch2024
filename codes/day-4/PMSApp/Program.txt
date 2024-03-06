using PMSApp.DAL;
using PMSApp.Data;
using Microsoft.Extensions.DependencyInjection;
using PMSApp.Entities;

namespace PMSApp
{
    internal class Program
    {
        static IServiceProvider[] ConfigureServiceProvider()
        {
            //configure service provider here
            var collectionOfServices = new ServiceCollection();
            collectionOfServices.AddSingleton<IInventory, Inventory>();

            var providerOfProductDao =
                collectionOfServices
                .AddSingleton<IDataAccess<Product>, ProductDao>()
                .BuildServiceProvider();

            var providerOfCategoryDao =
                collectionOfServices
                .AddSingleton<IDataAccess<Category>, CategoryDao>()
                .BuildServiceProvider();

            return [providerOfProductDao, providerOfCategoryDao];

            //var provider =
            //    collectionOfServices
            //    .AddSingleton<IInventory, Inventory>()
            //    .AddSingleton<IDataAccess<Product>, ProductDao>()
            //    .AddSingleton<IDataAccess<Category>, CategoryDao>()
            //    .BuildServiceProvider();

            //return provider;
        }
        static void Main()
        {
            //var provider = ConfigureServiceProvider();
            var providers = ConfigureServiceProvider();
            try
            {
                //var productDao = provider.GetRequiredService<IDataAccess<Product>>();
                var productDao = providers[0].GetRequiredService<IDataAccess<Product>>();
                var products = productDao.GetAll();
                foreach (var product in products)
                {
                    Console.WriteLine(product.Name);
                }

                //var categoryDao = provider.GetRequiredService<IDataAccess<Category>>();
                var categoryDao = providers[1].GetRequiredService<IDataAccess<Category>>();
                var categories = categoryDao.GetAll();
                foreach (var category in categories)
                {
                    Console.WriteLine(category.Name);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
