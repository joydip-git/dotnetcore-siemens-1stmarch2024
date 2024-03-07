using Microsoft.EntityFrameworkCore;
using SampleWebApiApp.Repository;
using Microsoft.Extensions.Configuration;

namespace SampleWebApiApp
{
    public class Program
    {
        public static void Main()
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder();

            Action<DbContextOptionsBuilder> optionBuilder = (options) =>
            {
                var connectionString =builder.Configuration.GetConnectionString("SiemensDbConStr");
                options.UseSqlServer(connectionString);
            };

            builder.Services.AddDbContext<SiemensDbContext>(optionBuilder);

            builder.Services.AddControllers();
            //builder.Services.AddAuthorization();            

            WebApplication app = builder.Build();

            //app.UseAuthorization();
            app.MapControllers();
            //app.MapControllerRoute(
            //    name: "default", 
            //    pattern:"{controller}/{action}/{id?}",
            //    defaults: new { controller = "Home", action = "Index" }
            //    );
            //app.MapGet("/myapi/welcome", () => "Hello World!");
            app.Run();
        }
    }
}
