using EFCoreApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EFCoreApp
{
    internal class Program
    {
        //
        static void Main()
        {
            string connectionString = @"server=joydip-pc\sqlexpress;database=siemensdb;user id=sa;password=SqlServer@2022;TrustServerCertificate=true";

            var services = new ServiceCollection();

            Action<DbContextOptionsBuilder> builder = (options) => options.UseSqlServer(connectionString);

            var provider = services
                .AddDbContext<SiemensDbContext>(builder)
                .BuildServiceProvider();

            //using (var db = new SiemensDbContext())
            using (var db = provider.GetRequiredService<SiemensDbContext>())
            {
                db.Database.EnsureCreated();


                //db.EmployeeInfos.Add(new Models.EmployeeInfo { Name = "vinod", Salary = 35000, Department = "HR" });
                //int res = db.SaveChanges();
                //Console.WriteLine(res > 0 ? "added" : "failed");

                db.EmployeeInfos.ToList().ForEach(e => Console.WriteLine($"{e.Name}, {e.Id},{e.Salary}, {e.Department??e.Department}"));
            }
        }
    }
}
