using PMSApp.DAL;
using PMSApp.Data;
using Microsoft.Extensions.DependencyInjection;
using PMSApp.Entities;
using PMSApp.BL;
using Microsoft.EntityFrameworkCore;

namespace PMSApp
{
    internal class Program
    {
        static IServiceProvider ConfigureServiceProvider()
        {
            //configure service provider here
            var collectionOfServices = new ServiceCollection();
            //collectionOfServices.AddSingleton<IInventory, Inventory>();
            collectionOfServices.AddDbContext<SiemensDbContext>(options => options.UseSqlServer(@"server=joydip-pc\sqlexpress;database=siemensdb;user id=sa;password=SqlServer@2022;TrustServerCertificate=true"));

            var provider =
                collectionOfServices
                //.AddSingleton<IInventory, Inventory>()
                .AddSingleton<IDataAccess<ProductDto>, ProductDao>()
                .AddSingleton<IDataAccess<CategoryDto>, CategoryDao>()
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
