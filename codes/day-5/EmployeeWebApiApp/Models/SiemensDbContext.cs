using Microsoft.EntityFrameworkCore;

namespace EmployeeWebApiApp.Models
{
    public class SiemensDbContext : DbContext
    {
        public DbSet<EmployeeInfo> EmployeeInfos { get; set; }

        public SiemensDbContext(DbContextOptions<SiemensDbContext> options) : base(options)
        {
        }
    }
}
