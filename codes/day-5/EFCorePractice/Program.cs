using EFCorePractice.DAO;
using EFCorePractice.DTOs;
using EFCorePractice.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace EFCorePractice
{
    internal class Program
    {

        static IServiceCollection CreateContainer()
        {
            return new ServiceCollection();
        }
        static IServiceProvider CreateServiceProvider()
        {
            var serviceContainer = CreateContainer();
            var provider=
                serviceContainer
                .AddDbContext<OrderCustomerDbContext>()
                .AddScoped<ICustomerDao<CustomerCreateDto,CustomerReadDto>,CustomerDao>()
                .BuildServiceProvider();

            return provider;
        }
        static void Main()
        {
            //using (var customerDao = new CustomerDao())
            //{
            //var customerDao = new CustomerDao(new OrderCustomerDbContext());

            var dbProvider = CreateServiceProvider();
            using (IServiceScope scope = dbProvider.CreateScope())
            {
               //var context = scope.ServiceProvider.GetRequiredService<OrderCustomerDbContext>();
                var customerDao = scope
                    .ServiceProvider
                    .GetRequiredService<
                        ICustomerDao<CustomerCreateDto, CustomerReadDto>>();

                //CustomerCreateDto dto = new CustomerCreateDto { Name = "ramnath", MailId = "ram@gmail.com", Mobile = 9090909094 };
                //customerDao.Add(dto);
                customerDao.GetAll().ToList().ForEach(c=>Console.WriteLine(c.Name));
            }
        }
    }
}
