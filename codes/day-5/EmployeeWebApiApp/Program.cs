using EmployeeWebApiApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeWebApiApp
{
    public class Program
    {
        static void ConfigureServices(WebApplicationBuilder builder)
        {
            //IServiceCollection services = builder.Services;
            //services.AddControllers();

            IConfiguration configuration = builder.Configuration;
            var connectionString = configuration
                .GetConnectionString("SiemensDbConStr");

            builder
                .Services
                .AddDbContext<SiemensDbContext>(
                (options) =>
                {
                    options.UseSqlServer(connectionString);
                }
                );

            //builder.Services.AddSingleton<LoggerMiddleware>();
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
        }
        public static void Main(string[] args)
        {    
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            ConfigureServices(builder);

            WebApplication app = builder.Build();

            // Configure the HTTP request pipeline.           
            ApplyMiddlewares(app);

            app.Run();
        }
        static void ApplyMiddlewares(WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //app.UseMyMiddleware();
            app.UseAuthorization();
            app.MapControllers();
        }
    }
}
