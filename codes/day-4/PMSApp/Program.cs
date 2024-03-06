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
        //configure service provider here
        static IServiceProvider ConfigureServiceProvider()
        {
            //create sevice collection object (a container to store objects of services for DI)
            var collectionOfServices = new ServiceCollection();

            //configure DbContext type for DI, so that during DI an object of SiemensDbContext class is created and placed in the service collection and provided by a service provider
            collectionOfServices.AddDbContext<SiemensDbContext>(
                options => options.UseSqlServer(@"server=joydip-pc\sqlexpress;database=siemensdb;user id=sa;password=SqlServer@2022;TrustServerCertificate=true")
                );

            //now create a service provider for DI of all services (business objects and dao objects) by registering further services (business and data access layer classes) for DI
            var provider =
                collectionOfServices
                .AddSingleton<IDataAccess<ProductCreateDto, ProductReadDto>, ProductDao>()
                .AddSingleton<IDataAccess<CategoryCreateDto, CategoryReadDto>, CategoryDao>()
                .AddSingleton<IProductBusinessComponent, ProductBO>()
                .BuildServiceProvider();

            return provider;
        }
        static void Main()
        {
            var provider = ConfigureServiceProvider();

            try
            {
                //ask service provider for DI of business class object
                //during creation of business object, DI framework will resolve its dependency on dao object and dao object's dependency on dbcontext object
                //hence first an instance of dbcontext will created and dependency injected in DAO instance and then the same instance of DAO will be dependency injected into an instance of BO class instance
                var productBo = provider.GetRequiredService<IProductBusinessComponent>();

                //fetching all products
                var products = productBo.FetchAll();
                products
                    .ToList()
                    .ForEach(p=>Console.WriteLine(p.Name));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
